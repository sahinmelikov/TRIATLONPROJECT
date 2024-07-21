using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriatlonProject.Migrations
{
    public partial class sonuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sonuc",
                table: "RaceRegisterUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sonuc",
                table: "RaceRegisterUsers");
        }
    }
}
