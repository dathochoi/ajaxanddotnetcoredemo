using Model.IRepository;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Repository
{
    public class EmployeeRepository : IEmployeeRepository<EmployeeDB>
    {
        readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public void Add(EmployeeDB entity)
        {
             _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

        public EmployeeDB Get(long id)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<EmployeeDB> GetAll()
        {
           return _context.Employees.ToList();
        }

        public void Update(EmployeeDB employee)
        {
            var emp = _context.Employees.Find(employee.ID);
            if (emp != null){

                emp.Name = employee.Name;
                emp.Salary = employee.Salary;
                emp.Status = employee.Status;
               // _context.Update(emp);
                _context.SaveChanges();
            }
        
           
          //  _context.SaveChanges();
        }
    }
}
