using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class image_for_animal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "animals");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "animals");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
