using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class updateRiddle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_riddles_animals_animalId",
                table: "riddles");

            migrationBuilder.DropIndex(
                name: "IX_riddles_animalId",
                table: "riddles");

            migrationBuilder.DropColumn(
                name: "animalId",
                table: "riddles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "animalId",
                table: "riddles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_riddles_animalId",
                table: "riddles",
                column: "animalId");

            migrationBuilder.AddForeignKey(
                name: "FK_riddles_animals_animalId",
                table: "riddles",
                column: "animalId",
                principalTable: "animals",
                principalColumn: "animalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
