using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AmendReferentialIntegrity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonSpecialismSpecialism");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSpecialism_SpecialismID",
                table: "PersonSpecialism",
                column: "SpecialismID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSpecialism_Specialism_SpecialismID",
                table: "PersonSpecialism",
                column: "SpecialismID",
                principalTable: "Specialism",
                principalColumn: "SpecialismID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSpecialism_Specialism_SpecialismID",
                table: "PersonSpecialism");

            migrationBuilder.DropIndex(
                name: "IX_PersonSpecialism_SpecialismID",
                table: "PersonSpecialism");

            migrationBuilder.CreateTable(
                name: "PersonSpecialismSpecialism",
                columns: table => new
                {
                    PersonSpecialismID = table.Column<int>(type: "int", nullable: false),
                    SpecialismID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSpecialismSpecialism", x => new { x.PersonSpecialismID, x.SpecialismID });
                    table.ForeignKey(
                        name: "FK_PersonSpecialismSpecialism_PersonSpecialism_PersonSpecialismID",
                        column: x => x.PersonSpecialismID,
                        principalTable: "PersonSpecialism",
                        principalColumn: "PersonSpecialismID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSpecialismSpecialism_Specialism_SpecialismID",
                        column: x => x.SpecialismID,
                        principalTable: "Specialism",
                        principalColumn: "SpecialismID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonSpecialismSpecialism_SpecialismID",
                table: "PersonSpecialismSpecialism",
                column: "SpecialismID");
        }
    }
}
