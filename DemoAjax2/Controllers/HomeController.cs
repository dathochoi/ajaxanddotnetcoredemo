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

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
          
            int totalRow = employee.GetAll().Count();

            var model = employee.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            });
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var model = employee.Get(id);

            return Json(new
            {
                data = model,
                status = true
            });
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
             employee.Delete(id);

            return Json(new
            {
              
                status = true
            });
        }

        [HttpPost]
        public JsonResult SaveData(string Name, float Salary, bool Status, int ID)
        {
            EmployeeDB emp = new EmployeeDB(ID,Name, Salary, Status) ;
            bool status = false;
            if(ID == 0)
            {
                emp.CreatedDate = DateTime.Now;
                employee.Add(emp);
              
                status = true;
            }
            else
            {
                //var entity = employee.Get(emp.ID);
                employee.Update(emp);
                status = true;
            }

            return Json(new
            {
                status 
            });
        }

        [HttpPost]
        public JsonResult Update(int ID, float Salary)
        {
            int id = ID;
            float salary = Salary;
            var entity = employee.Get(id);
            employee.Update( new EmployeeDB(id,salary));

            return Json(new
            {
                status = true
            });
        }
    }
}
