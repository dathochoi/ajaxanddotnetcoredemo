﻿var homeconfig = {
    pageSize: 5,
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
        });
        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            homeController.resetForm();
        });
        $('#btnSave').off('click').on('click', function () {
            homeController.saveData();
        });

        $('.btn-edit').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            var id = $(this).data('id');
            homeController.loadDetail(id);
        });
        $('.btn-delete').off('click').on('click', function () {  
            var id = $(this).data('id');
            homeController.delete(id);
        });
    },
    delete: function (id) {
       
        $.ajax({
            url: '/Home/Delete',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    alert("Removed")
                    homeController.loadData();
                }
                else {
                    alert("Error")
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
            
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/Home/GetDetail',
            data: { 
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#txtName').val(data.Name);
                    $('#txtSalary').val(data.Salary);
                    $('#ckStatus').prop('checked', data.Status);

                }
                else {
                    alert(res.mess);
                }
            },
            error: function (err) {
                console.log(err);
            }

        })
    },
    resetForm: function () {
        $('#hidID').val('0');
        $('#txtName').val('');
        $('#txtSalary').val(0);
        $('#ckStatus').prop('checked',true);
    },

    saveData: function () {
        var name = $('#txtName').val();
        var salary = parseFloat($('#txtSalary').val());
        var status = $('#ckStatus').prop('checked');
        var id = parseInt($('#hidID').val());

        $.ajax({
            url: '/Home/SaveData',
            data: {
               
                    Name: name,
                    Salary: salary,
                    Status: status,
                    ID: id
                    
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (status == true) {
                    alert('Save success');
                    $('#modalAddUpdate').modal('hide');
                   
                        homeController.loadData();
                 
                }
                else {
                    alert(res.mess);
                }
            },
            error: function (err) {
                console.log(err);
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