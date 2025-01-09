using Test3.Domin.Entities.Common;

namespace Test3.Domin.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    // Navigation property
    public ICollection<BranchDepartment> BranchDepartments { get; set; } = new List<BranchDepartment>();
}
