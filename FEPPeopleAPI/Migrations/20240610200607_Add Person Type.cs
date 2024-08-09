using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FEPPeopleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonTypeID",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    PersonTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.PersonTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeID",
                table: "Person",
                column: "PersonTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonType_PersonTypeID",
                table: "Person",
                column: "PersonTypeID",
                principalTable: "PersonType",
                principalColumn: "PersonTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_PersonType_PersonTypeID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonTypeID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonTypeID",
                table: "Person");
        }
    }
}
