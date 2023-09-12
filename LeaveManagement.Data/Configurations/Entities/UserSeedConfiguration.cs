using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configuration.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee 
                {
                    Id= "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    NormalizedUserName = "USER@GMAIL.COM",
                    UserName = "user@gmail.com",
                    FirstName = "User",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "T@sk123"),
                    EmailConfirmed = true

                },
                new Employee 
                {
                    Id = "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    UserName = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "T@sk1234"),
                    EmailConfirmed = true
                }
            );
        }
    }
}