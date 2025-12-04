using Employee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PartTimeEmployees.Models;
using System;
using System.Threading.Tasks;

namespace Employee.Data
{

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        // DbSet for Employee
        public DbSet<Employee> PartTimers { get; set; }
        public DbSet<Employee> employees { get; set; }

        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<EmployeeApi> Employees { get; set; }
        //public DbSet<IPartTimeEmployee> PartTimers { get; set; }
        //  public object PartTimeEmployee { get; internal set; }


    }
}




