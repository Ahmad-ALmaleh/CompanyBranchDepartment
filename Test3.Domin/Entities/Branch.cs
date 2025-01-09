using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test3.Domin.Entities.Common;

namespace Test3.Domin.Entities;

public class Branch : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Navigation property
    public ICollection<BranchDepartment> BranchDepartments { get; set; } = new List<BranchDepartment>();
}
