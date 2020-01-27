﻿var homeconfig = {
    pageSize: 3,
    pageIndex: 1,
}

var homeController = {
    init: function () {

        homeController.loadData();
        homeController.registerEvent();
    },

    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                homeController.updateSalary(id, value);
            }
        })
    },
    updateSalary: function (id, value) {
        var data = {
            ID: id,
            Salary: value
        };
        $.ajax({
            url: '/Home/Update',
            type: 'POST',
            dataType: 'json',
            data: {
                ID: id,
                Salary: value
            },
            success: function (response) {
                if (response.status == false) {
                    alert("false");
                }
                else {
                    alert("true");
                }
            }
        })
    },

    loadData: function () {
        $.ajax({
            url: '/Home/LoadData',
            type: 'GET',
            dataType: 'json',
            data: {
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            contentType: "application/json",
            success: function (response) {
                if (response.status) {
                    var data = [];
                    data = response.data;

                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class=\"label label-sccess\"> Actived</span>" : "<span class=\"label label-danger\"> Locked</span>"
                        });
                    });
                    $('#tblData').html(html);
                    homeController.paging(response.total, function () {
                        homeController.loadData();
                    });
                    homeController.registerEvent();

                }
            }
        })
    },
    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize);



        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev: "Trước",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
homeController.init();