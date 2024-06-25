using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class addFeedingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedules_animals_AnimalanimalId",
                table: "FeedingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FeedingSchedules_AnimalanimalId",
                table: "FeedingSchedules");

            migrationBuilder.DropColumn(
                name: "AnimalanimalId",
                table: "FeedingSchedules");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FeedingTime",
                table: "animals",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedingTime",
                table: "animals");

            migrationBuilder.AddColumn<int>(
                name: "AnimalanimalId",
                table: "FeedingSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_AnimalanimalId",
                table: "FeedingSchedules",
                column: "AnimalanimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedules_animals_AnimalanimalId",
                table: "FeedingSchedules",
                column: "AnimalanimalId",
                principalTable: "animals",
                principalColumn: "animalId");
        }
    }
}
