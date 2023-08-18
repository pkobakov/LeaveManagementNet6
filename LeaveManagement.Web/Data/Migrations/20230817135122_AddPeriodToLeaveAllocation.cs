using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "df573f63-8147-4563-bf75-8480de6f9d11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "18ecb93e-f075-4363-9045-6c4fa55a7e3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0219a3d-8efb-4b53-9d86-1367b279991c", "AQAAAAEAACcQAAAAEO1ru2oUHCNq0Q3WSPHxsdzr6x9w2UzMMpXmjV38KByMLEwxbacAP0nxuGII8IgwxA==", "4712088e-f130-4fbe-8c54-ea27dc608c52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d87716d-4d95-43d0-85cd-3b47f696a959", "AQAAAAEAACcQAAAAEB8P5XaNFTz1wyMC2uWzvw+j5tEp2L0beflYXI4FKA6kvvQEKCBu1iUu3oH8QnJH4A==", "56e54790-93b3-4dbd-81e3-59dd4bc4b2cb" });
        }
    }
}
