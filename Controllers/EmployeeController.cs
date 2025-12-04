using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Employee.Data;
using System;
using PartTimeEmployees.Models;
using Employee.Models;
using System.Collections.Generic;

namespace Employee.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Employees.Controllers
    {
        [ApiController]
        [Route("api/employees")] // Recommended route: /api/employees
        public class EmployeesController : ControllerBase
        {
            private readonly EmployeeDbContext _context;

            public EmployeesController(EmployeeDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
            {
                return await _context.employees.ToListAsync();
            }


            // GET: api/employees/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Employee>> GetEmployee(int id)
            {
                var employee = await _context.employees.FindAsync(id);
                if (employee == null)
                    return NotFound();

                return employee;
            }


            // POST: api/employees
            [HttpPost]
            public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
            {
                _context.employees.Add(employee);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmpId }, employee);
            }

            // PUT: api/employees/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutEmployee(int id, Employee employee)
            {
                if (id != employee.EmpId)
                    return BadRequest();

                _context.Entry(employee).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(id))
                        return NotFound();
                    else
                        throw;
                }

                return NoContent();
            }

            // DELETE: api/employees/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEmployee(int id)
            {
                var employee = await _context.employees.FindAsync(id);
                if (employee == null)
                    return NotFound();

                _context.employees.Remove(employee);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool EmployeeExists(int id)
            {
                return _context.employees.Any(e => e.EmpId == id);
            }
        }
    }
} 
