using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mabill.Data.Migrations
{
    public partial class UserOrganizationPropertyUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JournalId",
                table: "Loanees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Loans_JournalId",
                table: "Loans",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Loanees_JournalId",
                table: "Loanees",
                column: "JournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Journals_JournalId",
                table: "Loans",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Journals_JournalId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_JournalId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loanees_JournalId",
                table: "Loanees");

            migrationBuilder.DropColumn(
                name: "JournalId",
                table: "Loanees");
        }
    }
}
