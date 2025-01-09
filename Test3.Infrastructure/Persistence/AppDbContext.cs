using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test3.Domin.Entities;
using Test3.Domin.Entities.Common;
using Test3.Infrastructure.Identity.Configurations;
using Test3.Infrastructure.Identity.Models;

namespace Test3.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }


    public DbSet<Branch> Branchs { get; set; }
    public DbSet<BranchDepartment> BranchDepartments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ignore BaseEntity to avoid it being treated as a standalone entity
        modelBuilder.Ignore<BaseEntity>();

        // Apply configurations for roles and users
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        // Branch Configuration
        modelBuilder.Entity<Branch>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Branch>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Branch>()
            .HasMany(b => b.BranchDepartments)
            .WithOne(bd => bd.Branch)
            .HasForeignKey(bd => bd.BranchId);

        // BranchDepartment Configuration
        modelBuilder.Entity<BranchDepartment>()
            .HasKey(bd => bd.Id);

        modelBuilder.Entity<BranchDepartment>()
            .HasOne(bd => bd.Branch)
            .WithMany(b => b.BranchDepartments)
            .HasForeignKey(bd => bd.BranchId);

        modelBuilder.Entity<BranchDepartment>()
            .HasOne(bd => bd.Department)
            .WithMany(d => d.BranchDepartments)
            .HasForeignKey(bd => bd.DepartmentId);

        modelBuilder.Entity<BranchDepartment>()
            .HasMany(bd => bd.Employees)
            .WithOne(e => e.BranchDepartment)
            .HasForeignKey(e => e.BranchDepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Department Configuration
        modelBuilder.Entity<Department>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.BranchDepartments)
            .WithOne(bd => bd.Department)
            .HasForeignKey(bd => bd.DepartmentId);

        // Employee Configuration
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Employee>()
            .Property(e => e.AppUserId)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Employee>()
            .Property(e => e.JobTitle)
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .Property(e => e.CvFilePath)
            .HasMaxLength(200);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.BranchDepartment)
            .WithMany(bd => bd.Employees)
            .HasForeignKey(e => e.BranchDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // AppUser Configuration
        modelBuilder.Entity<AppUser>()
            .Property(au => au.FullName)
            .IsRequired()
            .HasMaxLength(150);
    }

}
