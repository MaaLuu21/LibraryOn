using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LoanDaysOverDue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysOverdue",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysOverdue",
                table: "Loans");
        }
    }
}
