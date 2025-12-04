using Employee.Models;
namespace Employee
{
    public class GetSalary:GetEmployee
    {
        public decimal salary;

        public int EmpId { get; set; }
        public string Name { get; set; }
        public required string GetEmployee { get => GetEmployee; set => GeEmployee = value; }
        public decimal  Salary { get => salary; set => salary = value; }

        public GetSalary(decimal salary)
        {
            Salary = salary;
        }
    }
}
