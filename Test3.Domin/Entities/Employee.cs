using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3.Domin.Entities;

public class Employee
{
    [Key]
    
    public string Id { get; set; } 
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string AppUserId { get; set; } = string.Empty;
    

    // New properties
    public decimal? Salary { get; set; } // Employee salary
    public string? JobTitle { get; set; } = string.Empty; // Job position
    public bool IsActive { get; set; } = true; // Is the employee active
    public DateTime HireDate { get; set; } = DateTime.UtcNow; // Hire date

    // New property for the CV file path
    public string? CvFilePath { get; set; } // Nullable in case no CV is uploaded

    public int? BranchDepartmentId { get; set; }
    public BranchDepartment BranchDepartment { get; set; } = null!;
}
