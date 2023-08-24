using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
