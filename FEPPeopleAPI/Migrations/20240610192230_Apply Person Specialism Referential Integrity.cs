using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplyPersonSpecialismReferentialIntegrity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialism_PersonSpecialism_PersonSpecialismID",
                table: "Specialism");

            migrationBuilder.DropIndex(
                name: "IX_Specialism_PersonSpecialismID",
                table: "Specialism");

            migrationBuilder.DropColumn(
                name: "PersonSpecialismID",
                table: "Specialism");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonSpecialismSpecialism");

            migrationBuilder.AddColumn<int>(
                name: "PersonSpecialismID",
                table: "Specialism",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialism_PersonSpecialismID",
                table: "Specialism",
                column: "PersonSpecialismID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialism_PersonSpecialism_PersonSpecialismID",
                table: "Specialism",
                column: "PersonSpecialismID",
                principalTable: "PersonSpecialism",
                principalColumn: "PersonSpecialismID");
        }
    }
}
