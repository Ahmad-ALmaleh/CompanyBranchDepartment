using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Test3.Domin.Entities;

namespace Test3.Infrastructure.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasData(
            new Branch { Id = 1, Name = "Head Office" },
            new Branch { Id = 2, Name = "Branch 1" }
        );
    }
}
