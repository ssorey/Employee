using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee.Models
{
    public interface IEmployeeApiController
    {
        JsonResult Delete(int id);
        Task<IActionResult> GetDeptById(int Id);
        Task<IActionResult> Post(GetEmployee employee);
        Task<IActionResult> Put(GetSalary salary);
    }
}