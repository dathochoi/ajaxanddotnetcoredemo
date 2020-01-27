using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoAjax2.Models;
using Model;
using Model.Model;
using Model.IRepository;

namespace DemoAjax2.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeRepository<EmployeeDB> employee;
        public HomeController(IEmployeeRepository<EmployeeDB> employee)
        {
            this.employee = employee;
        }

        List<EmployeeModel> listEmployee = new List<EmployeeModel>() {
            new EmployeeModel()
            {
                ID = 1,
                Name = "Nguyen Van A",
                Salary = 20000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 2,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 3,
                Name = "Nguyen Van C",
                Salary = 40000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 4,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 5,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 6,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 7,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 8,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 9,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            },
            new EmployeeModel()
            {
                ID = 10,
                Name = "Nguyen Van B",
                Salary = 30000,
                Status = true
            }
        };

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
            //int totalRow = listEmployee.Count();
            int totalRow = employee.GetAll().Count();

            //var model = listEmployee.Skip((page - 1) * pageSize).Take(pageSize);

            var model = employee.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(int ID, double Salary)
        {
            int id = ID;
            double salary = Salary;
            var entity = listEmployee.Find(x => x.ID == id);
            entity.Salary = salary;

            return Json(new
            {
                status = true
            });
        }
    }
}
