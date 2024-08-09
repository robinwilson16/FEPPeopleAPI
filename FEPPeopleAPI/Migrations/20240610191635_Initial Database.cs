using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Forename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PersonSpecialism",
                columns: table => new
                {
                    PersonSpecialismID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    SpecialismID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSpecialism", x => x.PersonSpecialismID);
                    table.ForeignKey(
                        name: "FK_PersonSpecialism_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialism",
                columns: table => new
                {
                    SpecialismID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialismName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true),
                    PersonSpecialismID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialism", x => x.SpecialismID);
                    table.ForeignKey(
                        name: "FK_Specialism_PersonSpecialism_PersonSpecialismID",
                        column: x => x.PersonSpecialismID,
                        principalTable: "PersonSpecialism",
                        principalColumn: "PersonSpecialismID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonSpecialism_PersonID",
                table: "PersonSpecialism",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialism_PersonSpecialismID",
                table: "Specialism",
                column: "PersonSpecialismID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialism");

            migrationBuilder.DropTable(
                name: "PersonSpecialism");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
