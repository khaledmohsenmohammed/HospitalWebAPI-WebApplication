using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebAPI.Migrations
{
    public partial class updatemodeluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "AdminApplicationUser",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AdminApplicationUser",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AdminApplicationUser");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AdminApplicationUser");
        }
    }
}
