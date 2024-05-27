using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Group_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IndexNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Group_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student_Group",
                columns: table => new
                {
                    IdGroup = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetUTCDATE()"),
                    StudentGroupIdGroup = table.Column<int>(type: "int", nullable: true),
                    StudentGroupIdStudent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StudentGroup_pk", x => new { x.IdGroup, x.IdStudent });
                    table.ForeignKey(
                        name: "FK_Student_Group_Student_Group_StudentGroupIdGroup_StudentGroupIdStudent",
                        columns: x => new { x.StudentGroupIdGroup, x.StudentGroupIdStudent },
                        principalTable: "Student_Group",
                        principalColumns: new[] { "IdGroup", "IdStudent" });
                    table.ForeignKey(
                        name: "StudentGroup_Group",
                        column: x => x.IdGroup,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "StudentGroup_Student",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "10c" },
                    { 2, "30c" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "FirstName", "IndexNumber", "LastName" },
                values: new object[,]
                {
                    { 1, "AA", "12354", "DD" },
                    { 2, "BB", "124565", "FFF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Group_IdStudent",
                table: "Student_Group",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Group_StudentGroupIdGroup_StudentGroupIdStudent",
                table: "Student_Group",
                columns: new[] { "StudentGroupIdGroup", "StudentGroupIdStudent" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Group");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
