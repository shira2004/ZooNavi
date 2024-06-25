using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class addtocagezooId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cages_zoos_ZooID",
                table: "Cages");

            migrationBuilder.RenameColumn(
                name: "ZooID",
                table: "Cages",
                newName: "ZooId");

            migrationBuilder.RenameIndex(
                name: "IX_Cages_ZooID",
                table: "Cages",
                newName: "IX_Cages_ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cages_zoos_ZooId",
                table: "Cages",
                column: "ZooId",
                principalTable: "zoos",
                principalColumn: "ZooID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cages_zoos_ZooId",
                table: "Cages");

            migrationBuilder.RenameColumn(
                name: "ZooId",
                table: "Cages",
                newName: "ZooID");

            migrationBuilder.RenameIndex(
                name: "IX_Cages_ZooId",
                table: "Cages",
                newName: "IX_Cages_ZooID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cages_zoos_ZooID",
                table: "Cages",
                column: "ZooID",
                principalTable: "zoos",
                principalColumn: "ZooID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
