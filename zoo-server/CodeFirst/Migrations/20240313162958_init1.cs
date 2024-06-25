using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cages_Cages_CageID1",
                table: "Cages");

            migrationBuilder.DropIndex(
                name: "IX_Cages_CageID1",
                table: "Cages");

            migrationBuilder.DropColumn(
                name: "CageID1",
                table: "Cages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CageID1",
                table: "Cages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cages_CageID1",
                table: "Cages",
                column: "CageID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cages_Cages_CageID1",
                table: "Cages",
                column: "CageID1",
                principalTable: "Cages",
                principalColumn: "CageID");
        }
    }
}
