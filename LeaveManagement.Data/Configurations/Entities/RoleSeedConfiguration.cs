﻿using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                Name = Roles.Administrator,
                NormalizedName = Roles.Administrator.ToUpper(),

            }, new IdentityRole
            {
                Id = "a7500931-e61a-4740-8d86-942f2d9f4af2",
                Name = Roles.User,
                NormalizedName = Roles.User.ToUpper(),
            }
            );
        }
    }
}