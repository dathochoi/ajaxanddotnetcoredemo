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
        }

        public void Delete(EmployeeDB employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeDB Get(long id)
        {
            return _context.Employees.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<EmployeeDB> GetAll()
        {
           return _context.Employees.ToList();
        }

        public void Update(EmployeeDB employee, EmployeeDB entity)
        {
            employee.Name = entity.Name;
            employee.Salary = entity.Salary;
            employee.Status = entity.Status;
            _context.SaveChanges();
        }
    }
}
