using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeDB> Employees { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDB>().HasData(
                new EmployeeDB
                {
                ID = 1,
                Name = "Nguyen Van A",
                Salary = 20000,
                CreatedDate = DateTime.Today,
                Status = true,

            }, new EmployeeDB
            {
                ID = 2,
                Name = "Nguyen Van B",
                Salary = 3000,
                CreatedDate = DateTime.Today,
                Status = true,
            },
                new EmployeeDB
                {
                    ID = 3,
                    Name = "Nguyen Van F",
                    Salary = 80000,
                    CreatedDate = DateTime.Today,
                    Status = true,
                },
                new EmployeeDB
                {
                    ID = 4,
                    Name = "Nguyen Van A",
                    Salary = 20000,
                    CreatedDate = DateTime.Today,
                    Status = true,
                },
                new EmployeeDB
                {
                    ID = 5,
                    Name = "Van D",
                    Salary = 5000,
                    CreatedDate = DateTime.Today,
                    Status = true,
                },
                new EmployeeDB
                {
                    ID = 6,
                    Name = " Van A",
                    Salary = 13000,
                    CreatedDate = DateTime.Today,
                    Status = true,
                },
                new EmployeeDB
                {
                    ID = 7,
                    Name = "Nguyen C",
                    Salary = 90000,
                    CreatedDate = DateTime.Today,
                    Status = true,
                }
                );
        }

    }
}
