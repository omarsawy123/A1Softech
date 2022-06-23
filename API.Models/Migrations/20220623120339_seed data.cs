using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Models.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Mobile", "Name", "Salary" },
                values: new object[] { new Guid("b975d1a1-d70a-4a1a-b65a-1e94a26990a5"), "Employee@gmail.com", 123456789, "First Employee", 1000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("b975d1a1-d70a-4a1a-b65a-1e94a26990a5"));
        }
    }
}
