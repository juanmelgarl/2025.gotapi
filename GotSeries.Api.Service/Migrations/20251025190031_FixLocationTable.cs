using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GotSeries.Api.Service.Migrations
{
    /// <inheritdoc />
    public partial class FixLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleTypes_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsCommander = table.Column<bool>(type: "bit", nullable: false),
                    IsKing = table.Column<bool>(type: "bit", nullable: false),
                    IsDeath = table.Column<bool>(type: "bit", nullable: false),
                    IsGeneric = table.Column<bool>(type: "bit", nullable: false),
                    IsHuman = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsRoyalty = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeathCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathCategories_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Summary = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CoatOfArmsUrl = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Kingdoms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Locations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Kingdoms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<byte>(type: "tinyint", nullable: false),
                    NroInSeason = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    OriginalDateAir = table.Column<DateOnly>(type: "date", nullable: false),
                    UsViewers = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleTypeId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    AttackerWon = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    HasMayorCapture = table.Column<bool>(type: "bit", nullable: false),
                    HasMayorDeath = table.Column<bool>(type: "bit", nullable: false),
                    AmountAttackerSoldiers = table.Column<int>(type: "int", nullable: false),
                    AmountDefenderSoldiers = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_BattleTypeId",
                        column: x => x.BattleTypeId,
                        principalTable: "BattleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    KilledId = table.Column<int>(type: "int", nullable: false),
                    KillerId = table.Column<int>(type: "int", nullable: true),
                    DeathCategoryId = table.Column<int>(type: "int", nullable: false),
                    DeathDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Reason = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    LocationComments = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Allegiance = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DeathCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deaths_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deaths_DeathCategoryId",
                        column: x => x.DeathCategoryId,
                        principalTable: "DeathCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deaths_KilledId",
                        column: x => x.KilledId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deaths_KillerId",
                        column: x => x.KillerId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deaths_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleCommanders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    CommanderId = table.Column<int>(type: "int", nullable: false),
                    IsAttacker = table.Column<bool>(type: "bit", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleCommanders_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleCommanders_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleCommanders_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleCommanders_CommanderId",
                        column: x => x.CommanderId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    IsAttacker = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleHouses_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleHouses_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleHouses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BattleKings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    KingId = table.Column<int>(type: "int", nullable: true),
                    IsAttacker = table.Column<bool>(type: "bit", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleKings_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleKings_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BattleKings_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleKings_KingId",
                        column: x => x.KingId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleCommanders_BattleId",
                table: "BattleCommanders",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCommanders_ChapterId",
                table: "BattleCommanders",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleCommanders_CommanderId",
                table: "BattleCommanders",
                column: "CommanderId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleHouses_BattleId",
                table: "BattleHouses",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleHouses_HouseId",
                table: "BattleHouses",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleKings_BattleId",
                table: "BattleKings",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleKings_ChapterId",
                table: "BattleKings",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleKings_KingId",
                table: "BattleKings",
                column: "KingId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_BattleTypeId",
                table: "Battles",
                column: "BattleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_LocationId",
                table: "Battles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SeasonId",
                table: "Chapters",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_ChapterId",
                table: "Deaths",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_DeathCategoryId",
                table: "Deaths",
                column: "DeathCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_KilledId",
                table: "Deaths",
                column: "KilledId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_KillerId",
                table: "Deaths",
                column: "KillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_LocationId",
                table: "Deaths",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_KingdomId",
                table: "Houses",
                column: "KingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_KingdomId",
                table: "Locations",
                column: "KingdomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleCommanders");

            migrationBuilder.DropTable(
                name: "BattleHouses");

            migrationBuilder.DropTable(
                name: "BattleKings");

            migrationBuilder.DropTable(
                name: "Deaths");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "DeathCategories");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "BattleTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
