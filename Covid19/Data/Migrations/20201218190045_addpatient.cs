using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class addpatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExitStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExitStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(maxLength: 150, nullable: false),
                    PName = table.Column<string>(maxLength: 250, nullable: false),
                    NationalId = table.Column<int>(maxLength: 14, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Job = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 350, nullable: true),
                    TicketNumber = table.Column<int>(nullable: false),
                    EnterDate = table.Column<DateTime>(nullable: false),
                    Report = table.Column<string>(nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    exitStatusId = table.Column<int>(nullable: true),
                    ExitDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "dbo",
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_ExitStatus_exitStatusId",
                        column: x => x.exitStatusId,
                        principalTable: "ExitStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_HospitalId",
                schema: "dbo",
                table: "Patient",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_exitStatusId",
                schema: "dbo",
                table: "Patient",
                column: "exitStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExitStatus");
        }
    }
}
