using Microsoft.EntityFrameworkCore.Migrations;

namespace Mabill.Data.Migrations
{
    public partial class CurrenyAddedToLoanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                table: "Loans",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomCurrencyType",
                table: "Loans",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CustomCurrencyType",
                table: "Loans");
        }
    }
}
