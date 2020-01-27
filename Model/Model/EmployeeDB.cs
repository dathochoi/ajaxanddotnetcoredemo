using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
    [Table("Employees")]
    public class EmployeeDB
    {
        public EmployeeDB(int id, float salary)
        {
            ID = id;
            Salary = salary;
        }

        public EmployeeDB(int id, string name, float salary, bool status)
        {
            ID = id;
            Name = name;
            Salary = salary;
            Status = status;
        }

        public EmployeeDB( )
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(255)]
       
        [Required]
        public string Name { get; set; }

        public float Salary { get; set; }

        [Required]
        public DateTime CreatedDate { set; get; }

        public bool Status { get; set; }

    }
}
