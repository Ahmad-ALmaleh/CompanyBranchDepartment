using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Test3.Infrastructure.Identity.Models;

namespace Test3.Infrastructure.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasData(
             new AppUser
             {
                 Id = "5e445865-a24d-4543-a6c6-9443d048cdb9",
                 FullName = "Administartor",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",

                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new AppUser
             {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 FullName = "RegularUser",
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",

                 UserName = "user@localhost.com",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}
