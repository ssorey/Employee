using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    
        public class EmployeeSalary
        {
            [Key]
            public int EmpId { get; set; }

            [Required]
            [StringLength(100)]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            [StringLength(100)]
            public string LastName { get; set; } = string.Empty;

            [Required]

            public required string Department { get; set; } = string.Empty;


            [Range(0, double.MaxValue)]
            public decimal Salary { get; set; }

            [DataType(DataType.Date)]
            public DateTime? HireDate { get; set; }



        public override int GetHashCode()
            {
                return HashCode.Combine(EmpId, FirstName, LastName, Department, Salary, HireDate);
            }
        }
    }


