using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Test3.Application.Contracts.Persistence;
using Test3.Application.DTOs.Employee;
using Test3.Infrastructure.Identity.Models;

namespace Test3.Infrastructure.Persistence.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper , UserManager<AppUser> userManager)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    // جلب الموظف بالاسم
    public async Task<EmployeeDto?> GetEmployeeByNameAsync(string name)
    {
        var employee = await _employeeRepository.GetAsync(e => e.FullName == name);
        return _mapper.Map<EmployeeDto>(employee);
    }

    // جلب جميع الموظفين
    public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    // تحديث بيانات الموظف
    public async Task<bool> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = await _employeeRepository.GetAsync(e => e.Id == employeeId);
        if (employee == null)
        {
            return false; // الموظف غير موجود
        }

        // تحديث الحقول الموجودة فقط
        _mapper.Map(updateEmployeeDto, employee);

        // جلب AppUser المرتبط
        var appUser = await _userManager.FindByIdAsync(employee.AppUserId);
        if (appUser == null)
        {
            throw new Exception($"AppUser with ID '{employee.AppUserId}' not found.");
        }
        // تحديث بيانات AppUser
        if (!string.IsNullOrWhiteSpace(updateEmployeeDto.Email))
        {
            appUser.Email = updateEmployeeDto.Email;
            appUser.UserName = updateEmployeeDto.Email; // إذا كان اسم المستخدم يعتمد على البريد الإلكتروني
        }

        if (!string.IsNullOrWhiteSpace(updateEmployeeDto.FullName))
        {
            appUser.FullName = updateEmployeeDto.FullName;
        }

        // تحديث بيانات AppUser
        var result = await _userManager.UpdateAsync(appUser);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        await _employeeRepository.UpdateAsync(employee);
        return true;
    }
}
