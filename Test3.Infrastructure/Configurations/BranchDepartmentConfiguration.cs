using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Test3.Domin.Entities;

namespace Test3.Infrastructure.Configurations;

public class BranchDepartmentConfiguration : IEntityTypeConfiguration<BranchDepartment>
{
    public void Configure(EntityTypeBuilder<BranchDepartment> builder)
    {
        builder.HasData(
            new BranchDepartment { Id = 1, BranchId = 1, DepartmentId = 1 }, // HR in Head Office
            new BranchDepartment { Id = 2, BranchId = 1, DepartmentId = 2 }, // IT in Head Office
            new BranchDepartment { Id = 3, BranchId = 2, DepartmentId = 1 }  // HR in Branch 1
        );
    }
}
