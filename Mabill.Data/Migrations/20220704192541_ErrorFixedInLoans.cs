using Microsoft.EntityFrameworkCore.Migrations;

namespace Mabill.Data.Migrations
{
    public partial class ErrorFixedInLoans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Loans_GivenById",
                table: "Loans",
                column: "GivenById");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TakenById",
                table: "Loans",
                column: "TakenById");

            migrationBuilder.CreateIndex(
                name: "IX_Loanees_AddedById",
                table: "Loanees",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Loanees_Users_AddedById",
                table: "Loanees",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_GivenById",
                table: "Loans",
                column: "GivenById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_TakenById",
                table: "Loans",
                column: "TakenById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loanees_Users_AddedById",
                table: "Loanees");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_GivenById",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_TakenById",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_GivenById",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_TakenById",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loanees_AddedById",
                table: "Loanees");
        }
    }
}
