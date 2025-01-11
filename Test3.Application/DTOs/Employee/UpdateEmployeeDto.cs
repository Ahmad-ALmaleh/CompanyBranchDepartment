using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3.Application.DTOs.Employee;

public class UpdateEmployeeDto
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? CvFilePath { get; set; }
    public decimal? Salary { get; set; }
    public string? JobTitle { get; set; }
    public bool? IsActive { get; set; }
    public int? BranchDepartmentId { get; set; }
}
