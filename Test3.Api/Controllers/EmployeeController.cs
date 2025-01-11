using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test3.Application.Contracts.Persistence;
using Test3.Application.DTOs.Employee;

namespace Test3.Api.Controllers
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

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee = await _employeeService.GetEmployeeByNameAsync(name);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        [Authorize]
       // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var updated = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
