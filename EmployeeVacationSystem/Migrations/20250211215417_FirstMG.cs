using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeVacationSystem.Migrations
{
    /// <inheritdoc />
    public partial class FirstMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "requestStates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestStates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "vacationTypes",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacationTypes", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    number = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    departmentID = table.Column<int>(type: "int", nullable: false),
                    positionID = table.Column<int>(type: "int", nullable: false),
                    genderCode = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    reportedToEmployeeNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    vacationDaysLeft = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.number);
                    table.ForeignKey(
                        name: "FK_employees_departments_departmentID",
                        column: x => x.departmentID,
                        principalTable: "departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employees_employees_reportedToEmployeeNumber",
                        column: x => x.reportedToEmployeeNumber,
                        principalTable: "employees",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employees_positions_positionID",
                        column: x => x.positionID,
                        principalTable: "positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacationRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestSubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    employeeNumber = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    vacationTypeCode = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false),
                    totalVacationDays = table.Column<int>(type: "int", nullable: false),
                    requestStateID = table.Column<int>(type: "int", nullable: false),
                    approvedByEmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    declinedByEmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacationRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_vacationRequests_employees_employeeNumber",
                        column: x => x.employeeNumber,
                        principalTable: "employees",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacationRequests_requestStates_requestStateID",
                        column: x => x.requestStateID,
                        principalTable: "requestStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacationRequests_vacationTypes_vacationTypeCode",
                        column: x => x.vacationTypeCode,
                        principalTable: "vacationTypes",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_departmentID",
                table: "employees",
                column: "departmentID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_positionID",
                table: "employees",
                column: "positionID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_reportedToEmployeeNumber",
                table: "employees",
                column: "reportedToEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_vacationRequests_employeeNumber",
                table: "vacationRequests",
                column: "employeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_vacationRequests_requestStateID",
                table: "vacationRequests",
                column: "requestStateID");

            migrationBuilder.CreateIndex(
                name: "IX_vacationRequests_vacationTypeCode",
                table: "vacationRequests",
                column: "vacationTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacationRequests");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "requestStates");

            migrationBuilder.DropTable(
                name: "vacationTypes");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
