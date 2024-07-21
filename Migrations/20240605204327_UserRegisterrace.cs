using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriatlonProject.Migrations
{
    public partial class UserRegisterrace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BiletQiymeti",
                table: "Races",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RaceRegisterUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comando = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ShirtSie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceRegisterUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceRegisterUsers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_RaceId",
                table: "Races",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceRegisterUsers_RaceId",
                table: "RaceRegisterUsers",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Races_RaceId",
                table: "Races",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Races_RaceId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "RaceRegisterUsers");

            migrationBuilder.DropIndex(
                name: "IX_Races_RaceId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "BiletQiymeti",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "Races");
        }
    }
}
