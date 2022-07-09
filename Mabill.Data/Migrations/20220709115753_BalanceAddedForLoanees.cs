using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mabill.Data.Migrations
{
    public partial class BalanceAddedForLoanees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInOrganization_Organizations_OrganizationId",
                table: "StaffInOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffInOrganization_Users_UserId",
                table: "StaffInOrganization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffInOrganization",
                table: "StaffInOrganization");

            migrationBuilder.RenameTable(
                name: "StaffInOrganization",
                newName: "StaffsInOrganizations");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInOrganization_UserId",
                table: "StaffsInOrganizations",
                newName: "IX_StaffsInOrganizations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffInOrganization_OrganizationId",
                table: "StaffsInOrganizations",
                newName: "IX_StaffsInOrganizations_OrganizationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "JournalId",
                table: "Loanees",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffsInOrganizations",
                table: "StaffsInOrganizations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LoaneesBalanceInJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    JournalId = table.Column<Guid>(type: "uuid", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    LoaneeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaneesBalanceInJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoaneesBalanceInJournals_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoaneesBalanceInJournals_Loanees_LoaneeId",
                        column: x => x.LoaneeId,
                        principalTable: "Loanees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoaneesBalanceInJournals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaneesBalanceInJournals_JournalId",
                table: "LoaneesBalanceInJournals",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaneesBalanceInJournals_LoaneeId",
                table: "LoaneesBalanceInJournals",
                column: "LoaneeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoaneesBalanceInJournals_UserId",
                table: "LoaneesBalanceInJournals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffsInOrganizations_Organizations_OrganizationId",
                table: "StaffsInOrganizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffsInOrganizations_Users_UserId",
                table: "StaffsInOrganizations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffsInOrganizations_Organizations_OrganizationId",
                table: "StaffsInOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffsInOrganizations_Users_UserId",
                table: "StaffsInOrganizations");

            migrationBuilder.DropTable(
                name: "LoaneesBalanceInJournals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffsInOrganizations",
                table: "StaffsInOrganizations");

            migrationBuilder.RenameTable(
                name: "StaffsInOrganizations",
                newName: "StaffInOrganization");

            migrationBuilder.RenameIndex(
                name: "IX_StaffsInOrganizations_UserId",
                table: "StaffInOrganization",
                newName: "IX_StaffInOrganization_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffsInOrganizations_OrganizationId",
                table: "StaffInOrganization",
                newName: "IX_StaffInOrganization_OrganizationId");

            migrationBuilder.AlterColumn<Guid>(
                name: "JournalId",
                table: "Loanees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffInOrganization",
                table: "StaffInOrganization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loanees_Journals_JournalId",
                table: "Loanees",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInOrganization_Organizations_OrganizationId",
                table: "StaffInOrganization",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffInOrganization_Users_UserId",
                table: "StaffInOrganization",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
