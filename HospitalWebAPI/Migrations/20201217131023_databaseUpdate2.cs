using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebAPI.Migrations
{
    public partial class databaseUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "icuID",
                table: "Hospital",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "iCU",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numnerOfDevaises = table.Column<int>(type: "int", nullable: false),
                    numberOfBed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iCU", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_icuID",
                table: "Hospital",
                column: "icuID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospital_iCU_icuID",
                table: "Hospital",
                column: "icuID",
                principalTable: "iCU",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospital_iCU_icuID",
                table: "Hospital");

            migrationBuilder.DropTable(
                name: "iCU");

            migrationBuilder.DropIndex(
                name: "IX_Hospital_icuID",
                table: "Hospital");

            migrationBuilder.DropColumn(
                name: "icuID",
                table: "Hospital");
        }
    }
}
