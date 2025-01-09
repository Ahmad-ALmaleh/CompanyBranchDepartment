
namespace Test3.Domin.Entities;

public class BranchDepartment
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int DepartmentId { get; set; }

    // Navigation properties
    public Branch Branch { get; set; } = null!;
    public Department Department { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
