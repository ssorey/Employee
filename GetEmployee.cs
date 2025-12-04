//using Amazon.AutoScaling.Model;
using System.ComponentModel.DataAnnotations;

namespace Employee
{
    public class GetEmployee
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Title { get; set; }

        [Range(0, double.MaxValue)]
        public required string GeEmployee { get => GeEmployee; set => GeEmployee = value; }
        public decimal Salary { get => Salary; set => Salary = value; }


    }
}

