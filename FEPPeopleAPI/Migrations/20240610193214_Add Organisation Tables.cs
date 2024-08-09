using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganisationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationStatus",
                columns: table => new
                {
                    OrganisationStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationStatus", x => x.OrganisationStatusID);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationType",
                columns: table => new
                {
                    OrganisationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationType", x => x.OrganisationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationTypeID = table.Column<int>(type: "int", nullable: true),
                    OrganisationStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.OrganisationID);
                    table.ForeignKey(
                        name: "FK_Organisation_OrganisationStatus_OrganisationStatusID",
                        column: x => x.OrganisationStatusID,
                        principalTable: "OrganisationStatus",
                        principalColumn: "OrganisationStatusID");
                    table.ForeignKey(
                        name: "FK_Organisation_OrganisationType_OrganisationTypeID",
                        column: x => x.OrganisationTypeID,
                        principalTable: "OrganisationType",
                        principalColumn: "OrganisationTypeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_OrganisationStatusID",
                table: "Organisation",
                column: "OrganisationStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_OrganisationTypeID",
                table: "Organisation",
                column: "OrganisationTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "OrganisationStatus");

            migrationBuilder.DropTable(
                name: "OrganisationType");
        }
    }
}
