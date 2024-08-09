using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonAvailability",
                columns: table => new
                {
                    PersonAvailabilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAvailability", x => x.PersonAvailabilityID);
                    table.ForeignKey(
                        name: "FK_PersonAvailability_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAvailability_PersonID",
                table: "PersonAvailability",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAvailability");
        }
    }
}
