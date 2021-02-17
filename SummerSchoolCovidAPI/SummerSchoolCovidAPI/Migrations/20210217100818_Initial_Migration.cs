using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerSchoolCovidAPI.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfectedUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Infected = table.Column<bool>(type: "bit", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfectedUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CovidCases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InfectedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TestLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateActioned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CovidCases_InfectedUsers_InfectedUserId",
                        column: x => x.InfectedUserId,
                        principalTable: "InfectedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CovidCaseContacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CovidCaseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InfectedUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidCaseContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CovidCaseContacts_CovidCases_CovidCaseId",
                        column: x => x.CovidCaseId,
                        principalTable: "CovidCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CovidCaseContacts_InfectedUsers_InfectedUserId",
                        column: x => x.InfectedUserId,
                        principalTable: "InfectedUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CovidCaseContacts_CovidCaseId",
                table: "CovidCaseContacts",
                column: "CovidCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CovidCaseContacts_InfectedUserId",
                table: "CovidCaseContacts",
                column: "InfectedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CovidCases_InfectedUserId",
                table: "CovidCases",
                column: "InfectedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidCaseContacts");

            migrationBuilder.DropTable(
                name: "CovidCases");

            migrationBuilder.DropTable(
                name: "InfectedUsers");
        }
    }
}
