using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test3.Application.DTOs.Employee;

namespace Test3.Application.Contracts.Persistence
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> GetEmployeeByNameAsync(string name);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<bool> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto updateEmployeeDto);
    }
}
