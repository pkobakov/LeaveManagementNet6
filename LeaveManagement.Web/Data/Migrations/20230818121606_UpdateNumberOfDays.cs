using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdateNumberOfDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "7aa077d6-8ac1-49dc-9260-a7df9e82071a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "44d73970-2ab2-4285-aab2-862b5b3f752e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdfaca1f-1c02-4b8e-8069-bda61f0f7625", "AQAAAAEAACcQAAAAEHD/5cgdNCElnu9p57a0Ag5acdzIK5/us6PkTDS366tNi1ZIwt8lrNbIcvpepZ1s/g==", "5a52613c-3c2f-4e40-b6f7-46a2d08f7a18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d08273f-1d59-4304-a242-dc80e36591ff", "AQAAAAEAACcQAAAAENAfya2BN9+QfVLqpb2+/AMVXWiXK7bu8etsNYTi1UlU+Sbd54mIeb016C/9rcr8dQ==", "1c955252-593a-4a05-bb7b-ee1bf7741322" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "99c385d4-332e-4825-a445-3eaf79643a09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "c80c9cfa-4594-4746-8728-225251b172ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a31f337-5dfe-4f26-9eac-1665d9e0a02e", "AQAAAAEAACcQAAAAEJyjlbVSDCKBR5AeqeO97iWbXmyWhqbs08Nf95AbHFy5yOzHs7Fsvs7JrOFRHkBDWA==", "13a19e44-abca-4499-9d18-eb39f876436b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "880db755-05d5-42d3-b409-a5fd9df739ee", "AQAAAAEAACcQAAAAEFmFIPi2EOjW8Ic0utQ88oFttCHJu1Ju/knzfFURX+GnWWmZqMdRo8sUxcHEDJkueA==", "dcd90a7e-1f3a-4423-83bd-1dd6d974ad8e" });
        }
    }
}
