using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configuration.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> 
                {
                  RoleId = "a7500931-e61a-4740-8d86-942f2d9f4af2",
                  UserId = "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43"
                },
                new IdentityUserRole<string> 
                {
                   RoleId = "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                   UserId = "c7500931-e61a-4740-8d86-942f2d9f4aa2"
                }
             );
        }

    }
}