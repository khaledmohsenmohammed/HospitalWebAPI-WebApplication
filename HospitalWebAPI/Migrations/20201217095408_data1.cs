using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebAPI.Migrations
{
    public partial class data1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AdminApplicationUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AdminApplicationUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
