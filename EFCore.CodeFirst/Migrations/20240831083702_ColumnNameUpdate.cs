using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Managers",
                newName: "Last Name");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Managers",
                newName: "First Name");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Managers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Person_LastName",
                table: "Employees",
                newName: "Last Name");

            migrationBuilder.RenameColumn(
                name: "Person_FirstName",
                table: "Employees",
                newName: "First Name");

            migrationBuilder.RenameColumn(
                name: "Person_Age",
                table: "Employees",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last Name",
                table: "Managers",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "First Name",
                table: "Managers",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Managers",
                newName: "Person_Age");

            migrationBuilder.RenameColumn(
                name: "Last Name",
                table: "Employees",
                newName: "Person_LastName");

            migrationBuilder.RenameColumn(
                name: "First Name",
                table: "Employees",
                newName: "Person_FirstName");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Employees",
                newName: "Person_Age");
        }
    }
}
