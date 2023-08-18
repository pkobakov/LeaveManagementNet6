using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdateNumberOfDaysDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "198342e7-0c3f-45df-9b34-594bcdb26c5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "ee0a9677-e2c4-471f-95bc-18081a4060a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29d952f2-83da-4146-aebf-43c7d0600c42", "AQAAAAEAACcQAAAAEK8S01M3gVrWY0Xd80VP6Uihio7yGDOVHtRCKIf64ItCwVO70HVYTTmVO0z2oA/X2g==", "f165e6c0-3a4b-451e-9fbb-c164ac7c951c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a8c6aa-d3b7-4ae6-8942-77cf67769389", "AQAAAAEAACcQAAAAEBRHZ1h4aDoMZU4ZIqqMojdUrXp+SdK7kJ0F6X61hZBqfSpWzJICVT9SG1eHxHXElQ==", "abc09899-e874-4a88-8f66-85ad51d1eb1d" });
        }
    }
}
