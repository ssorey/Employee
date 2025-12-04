using System;
using Employee.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Employee.Models
{


    public abstract class GetSalary
    {
        public virtual decimal GetSalaryAmount() => 0;
    }

    public class PartTimeEmployee : GetSalary
    {
        public int EmpId { get; set; }
        public required string Name { get; set; }

        public PartTimeEmployee(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Department { get; set; } = "Part Time Department";
        public decimal Salary { get; set; } = 30000;

        public override decimal GetSalaryAmount() => Salary;
    }
}