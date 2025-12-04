namespace PartTimeEmployees.Models
{
    public class PartTimeEmployee : IPartTimeEmployee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; internal set; }

        public void SetEmpId(int id)
        {
            EmpId = id;
        }

        public string GetName()
        {
            return Name;
        }

        public decimal GetSalary()
        {
            return Salary;
        }
    }

    public interface IPartTimeEmployee
    {
    }
}
