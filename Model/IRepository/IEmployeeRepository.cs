using Model.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.IRepository
{
    public interface IEmployeeRepository<EmployeeDB>
    {
        IEnumerable<EmployeeDB> GetAll();
        EmployeeDB Get(long id);
        void Add(EmployeeDB entity);
        void Update(EmployeeDB employee);
        void Delete(int id);
    }
}
