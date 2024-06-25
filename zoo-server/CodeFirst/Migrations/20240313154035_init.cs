using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "zoos",
                columns: table => new
                {
                    ZooID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zoos", x => x.ZooID);
                });

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    CageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZooID = table.Column<int>(type: "int", nullable: false),
                    CageID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.CageID);
                    table.ForeignKey(
                        name: "FK_Cages_Cages_CageID1",
                        column: x => x.CageID1,
                        principalTable: "Cages",
                        principalColumn: "CageID");
                    table.ForeignKey(
                        name: "FK_Cages_zoos_ZooID",
                        column: x => x.ZooID,
                        principalTable: "zoos",
                        principalColumn: "ZooID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kiosks",
                columns: table => new
                {
                    KioskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZooID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kiosks", x => x.KioskID);
                    table.ForeignKey(
                        name: "FK_kiosks_zoos_ZooID",
                        column: x => x.ZooID,
                        principalTable: "zoos",
                        principalColumn: "ZooID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<int>(type: "int", nullable: false),
                    ZooID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_tickets_zoos_ZooID",
                        column: x => x.ZooID,
                        principalTable: "zoos",
                        principalColumn: "ZooID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    animalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.animalId);
                    table.ForeignKey(
                        name: "FK_animals_Cages_CageID",
                        column: x => x.CageID,
                        principalTable: "Cages",
                        principalColumn: "CageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedingSchedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    AnimalanimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingSchedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_FeedingSchedules_animals_AnimalanimalId",
                        column: x => x.AnimalanimalId,
                        principalTable: "animals",
                        principalColumn: "animalId");
                    table.ForeignKey(
                        name: "FK_FeedingSchedules_Cages_CageID",
                        column: x => x.CageID,
                        principalTable: "Cages",
                        principalColumn: "CageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animals_CageID",
                table: "animals",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_CageID1",
                table: "Cages",
                column: "CageID1");

            migrationBuilder.CreateIndex(
                name: "IX_Cages_ZooID",
                table: "Cages",
                column: "ZooID");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_AnimalanimalId",
                table: "FeedingSchedules",
                column: "AnimalanimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_CageID",
                table: "FeedingSchedules",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_kiosks_ZooID",
                table: "kiosks",
                column: "ZooID");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_ZooID",
                table: "tickets",
                column: "ZooID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedingSchedules");

            migrationBuilder.DropTable(
                name: "kiosks");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "zoos");
        }
    }
}
