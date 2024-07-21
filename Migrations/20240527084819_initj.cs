using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriatlonProject.Migrations
{
    public partial class initj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTranslations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTranslations",
                columns: table => new
                {
                    PersonTranslationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranslatedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTranslations", x => x.PersonTranslationId);
                    table.ForeignKey(
                        name: "FK_PersonTranslations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTranslations_PersonId",
                table: "PersonTranslations",
                column: "PersonId");
        }
    }
}
