using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdateLeaveRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "d95789f0-938a-4f93-8ea9-9d913fa9815e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "d08eb275-71dd-4039-abd4-00a0ff732ac3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35287434-9e08-4b45-96f9-34048de3b125", "AQAAAAEAACcQAAAAEAXb3uvofcdEyfGNxyKuZsARGBwQcHy22JoLZToEqDvenva5Uj8X0gf1xalaZaFyng==", "924f2cd4-4202-4909-98c2-eaa1c1d3e152" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e6a3388-0036-4c21-9791-0cef4b452992", "AQAAAAEAACcQAAAAEAc+nelzBw1N1mMBFcsQlCLbUgTclRgFOmfMW10KgwMjEbi9QWpQiwmwDZM5TJ3ndA==", "c615a2ac-7e78-4020-87df-994ba4e39f51" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7500931-e61a-4740-8d86-942f2d9f4af2",
                column: "ConcurrencyStamp",
                value: "54668736-989f-49a1-9fb5-3e146012ffcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7500931-e62a-4840-8d86-942f2d9f4aa2",
                column: "ConcurrencyStamp",
                value: "2405f478-2ac0-4000-ba7a-07a5ac0f994b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "545ffba8-8f95-4d40-8f7b-4e9f5daa8d43",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abc2aaa2-f89f-4ce7-90b3-f4997093ae45", "AQAAAAEAACcQAAAAEKiP9eyRujQYIjSSNz4lvwd4MHjDVFmthLo5ykrsOQhGXzVsFGJO4QrnVZF9ftbgBQ==", "932b3b19-1f64-4944-8b99-771456e7e7c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7500931-e61a-4740-8d86-942f2d9f4aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48afbe48-8801-4b1c-bcdc-bc7911b48e4c", "AQAAAAEAACcQAAAAEJa6t8W3/pUuCAxCDiznD7/Mkws7m3/g8voheGJNWbWH7MLjXEbYnTcozjMUq5zQeQ==", "49b8729f-f9f2-451a-a4f7-2b73bbf8cb49" });
        }
    }
}
