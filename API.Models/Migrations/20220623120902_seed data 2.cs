using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Models.Migrations
{
    public partial class seeddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("b975d1a1-d70a-4a1a-b65a-1e94a26990a5"));

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Mobile", "Name", "Salary" },
                values: new object[] { new Guid("cba9e2a4-ceeb-41cd-9c4a-d293b314bf9c"), "Employee@gmail.com", 123456789, "First Employee", 1000f });

            migrationBuilder.InsertData(
                table: "EmployeeTax",
                columns: new[] { "Id", "EmployeeId", "NetSalary", "Tax" },
                values: new object[] { new Guid("497f7d22-eaf9-45c1-99dd-ca774dedfdb3"), new Guid("cba9e2a4-ceeb-41cd-9c4a-d293b314bf9c"), 900f, 10f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeTax",
                keyColumn: "Id",
                keyValue: new Guid("497f7d22-eaf9-45c1-99dd-ca774dedfdb3"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("cba9e2a4-ceeb-41cd-9c4a-d293b314bf9c"));

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Mobile", "Name", "Salary" },
                values: new object[] { new Guid("b975d1a1-d70a-4a1a-b65a-1e94a26990a5"), "Employee@gmail.com", 123456789, "First Employee", 1000f });
        }
    }
}
