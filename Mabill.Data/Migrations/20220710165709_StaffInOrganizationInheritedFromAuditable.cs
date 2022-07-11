using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Mabill.Data.Migrations
{
    public partial class StaffInOrganizationInheritedFromAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "StaffsInOrganizations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StaffsInOrganizations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "StaffsInOrganizations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "StaffsInOrganizations",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificatedDate",
                table: "StaffsInOrganizations",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "StaffsInOrganizations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StaffsInOrganizations",
                type: "varchar(24)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "LastModificatedDate",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StaffsInOrganizations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StaffsInOrganizations");
        }
    }
}
