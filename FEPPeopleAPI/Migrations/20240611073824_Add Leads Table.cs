using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLeadsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    LeadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    EnquiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EstimatedDays = table.Column<int>(type: "int", nullable: false),
                    EstimatedDayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.LeadID);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectID = table.Column<int>(type: "int", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteID);
                });

            migrationBuilder.CreateTable(
                name: "LeadDay",
                columns: table => new
                {
                    LeadDayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadID = table.Column<int>(type: "int", nullable: false),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadDay", x => x.LeadDayID);
                    table.ForeignKey(
                        name: "FK_LeadDay_Lead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Lead",
                        principalColumn: "LeadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadSpecialism",
                columns: table => new
                {
                    LeadSpecialismID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialismID = table.Column<int>(type: "int", nullable: false),
                    LeadID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSpecialism", x => x.LeadSpecialismID);
                    table.ForeignKey(
                        name: "FK_LeadSpecialism_Lead_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Lead",
                        principalColumn: "LeadID");
                    table.ForeignKey(
                        name: "FK_LeadSpecialism_Specialism_SpecialismID",
                        column: x => x.SpecialismID,
                        principalTable: "Specialism",
                        principalColumn: "SpecialismID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_OrganisationID",
                table: "Contract",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PersonID",
                table: "Contract",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDay_LeadID",
                table: "LeadDay",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSpecialism_LeadID",
                table: "LeadSpecialism",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSpecialism_SpecialismID",
                table: "LeadSpecialism",
                column: "SpecialismID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Organisation_OrganisationID",
                table: "Contract",
                column: "OrganisationID",
                principalTable: "Organisation",
                principalColumn: "OrganisationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Person_PersonID",
                table: "Contract",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Organisation_OrganisationID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Person_PersonID",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "LeadDay");

            migrationBuilder.DropTable(
                name: "LeadSpecialism");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropIndex(
                name: "IX_Contract_OrganisationID",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_PersonID",
                table: "Contract");
        }
    }
}
