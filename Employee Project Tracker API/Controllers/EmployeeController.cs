using Employee_Project_Tracker_API.Models;
using Employee_Project_Tracker_API.ServiceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Project_Tracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
            private readonly IEmployeeService _employeeService;

            public EmployeeController(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            // GET: api/employee
            [HttpGet]
            public async Task<IActionResult> GetAllEmployees()
            {
                var employees = await _employeeService.GetAllEmployees();
                return Ok(employees);
            }

            // GET: api/employee/{id}
            [HttpGet("{id}")]
            public async Task<IActionResult> GetEmployeeById(int id)
            {
                var employee = await _employeeService.GetEmployeeByID(id);
                if (employee == null)
                    return NotFound($"Employee with ID {id} not found.");
                return Ok(employee);
            }

            // POST: api/employee
            [HttpPost]
            public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
            {
                if (employee == null)
                    return BadRequest("Invalid employee data.");

                var createdEmployee = await _employeeService.Add(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }

            // PUT: api/employee/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
            {
                if (employee == null || id != employee.EmployeeId)
                    return BadRequest("Employee data mismatch.");

                var updatedEmployee = await _employeeService.Update(id, employee);
                if (updatedEmployee == null)
                    return NotFound($"Employee with ID {id} not found.");

                return Ok(updatedEmployee);
            }

            // DELETE: api/employee/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEmployee(int id)
            {
                var deleted = await _employeeService.Delete(id);
                if (!deleted)
                    return NotFound($"Employee with ID {id} not found.");

                return NoContent();
            }
        }
    
}
