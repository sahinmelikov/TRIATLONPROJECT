using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriatlonProject.Migrations
{
    public partial class sonuclaraciklandi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sonuclarAciklandis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sonuclarAciklandis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sonuclarAciklandis_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sonuclarAciklandis_RaceId",
                table: "sonuclarAciklandis",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sonuclarAciklandis");
        }
    }
}
