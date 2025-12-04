using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    internal class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 👈 This tells EF Core to auto-generate the value
        public int EmpId { get; set; }


        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;


        //   [StringLength(100)]
        //    public string? Title { get; set; }

        //   [Range(0, double.MaxValue)]
        //  public decimal Salary { get; set; }
        //  public int EmpId { get; internal set; }
    }

}
