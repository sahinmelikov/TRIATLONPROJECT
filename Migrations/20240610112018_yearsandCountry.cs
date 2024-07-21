using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriatlonProject.Migrations
{
    public partial class yearsandCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountrysId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yearss = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_CountrysId",
                table: "Races",
                column: "CountrysId");

            migrationBuilder.CreateIndex(
                name: "IX_Races_YearId",
                table: "Races",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Country_CountrysId",
                table: "Races",
                column: "CountrysId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Year_YearId",
                table: "Races",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Country_CountrysId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Year_YearId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropIndex(
                name: "IX_Races_CountrysId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_YearId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Races");
        }
    }
}
