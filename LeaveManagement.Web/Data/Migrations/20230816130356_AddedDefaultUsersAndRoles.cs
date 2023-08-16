using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7500931-e61a-4740-8d86-942f2d9f4af2", "df573f63-8147-4563-bf75-8480de6f9d11", "User", "USER" },
                    { "c7500931-e62a-4840-8d86-942f2d9f4aa2", "18ecb93e-f075-4363-9045-6c4fa55a7e3b", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxtId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43", 0, "d0219a3d-8efb-4b53-9d86-1367b279991c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", true, "User", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEO1ru2oUHCNq0Q3WSPHxsdzr6x9w2UzMMpXmjV38KByMLEwxbacAP0nxuGII8IgwxA==", null, false, "4712088e-f130-4fbe-8c54-ea27dc608c52", null, false, "user@gmail.com" },
                    { "c7500931-e61a-4740-8d86-942f2d9f4aa2", 0, "1d87716d-4d95-43d0-85cd-3b47f696a959", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEB8P5XaNFTz1wyMC2uWzvw+j5tEp2L0beflYXI4FKA6kvvQEKCBu1iUu3oH8QnJH4A==", null, false, "56e54790-93b3-4dbd-81e3-59dd4bc4b2cb", null, false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a7500931-e61a-4740-8d86-942f2d9f4af2", "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7500931-e62a-4840-8d86-942f2d9f4aa2", "c7500931-e61a-4740-8d86-942f2d9f4aa2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7500931-e61a-4740-8d86-942f2d9f4af2", "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7500931-e62a-4840-8d86-942f2d9f4aa2", "c7500931-e61a-4740-8d86-942f2d9f4aa2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2");
        }
    }
}
