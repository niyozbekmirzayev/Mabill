using Microsoft.EntityFrameworkCore.Migrations;

namespace Mabill.Data.Migrations
{
    public partial class ForignKeysForEachEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SumOfGivenLoans",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SumOfLoans",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SumOfRepaidLoans",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SumOfLoans",
                table: "Loanees");

            migrationBuilder.DropColumn(
                name: "SumOfRepaidLoans",
                table: "Loanees");

            migrationBuilder.DropColumn(
                name: "SumOfGivenLoans",
                table: "Journals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SumOfGivenLoans",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOfLoans",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOfRepaidLoans",
                table: "Users",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOfLoans",
                table: "Loanees",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOfRepaidLoans",
                table: "Loanees",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SumOfGivenLoans",
                table: "Journals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
