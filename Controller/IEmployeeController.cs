using Employee.Data;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;

public interface IEmployeeController
{
    Task<ActionResult<FullTimeEmployee>> CreateEmployee(FullTimeEmployee employee);
     Task<IActionResult> DeleteEmployee(int id);
    Task<ActionResult<FullTimeEmployee>> GetEmployee(int id);
    Task<ActionResult<IEnumerable<FullTimeEmployee>>> GetEmployees();
   
}