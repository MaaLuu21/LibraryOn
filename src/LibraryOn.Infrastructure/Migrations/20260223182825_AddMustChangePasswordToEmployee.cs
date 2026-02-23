using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMustChangePasswordToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MustChangePassword",
                table: "Employees",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MustChangePassword",
                table: "Employees");
        }
    }
}
