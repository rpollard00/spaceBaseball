using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceBaseball.Adapter.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Constitution = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Wisdom = table.Column<int>(type: "INTEGER", nullable: false),
                    Charisma = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    HitChance = table.Column<int>(type: "INTEGER", nullable: false),
                    Fielding = table.Column<int>(type: "INTEGER", nullable: false),
                    AbilityScoresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AbilityScores_AbilityScoresId",
                        column: x => x.AbilityScoresId,
                        principalTable: "AbilityScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Ballpark = table.Column<string>(type: "TEXT", nullable: false),
                    RosterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Roster_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Roster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BullpenEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: false),
                    RosterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BullpenEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BullpenEntry_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BullpenEntry_Roster_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Roster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionPlayerEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: false),
                    RosterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPlayerEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionPlayerEntry_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionPlayerEntry_Roster_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Roster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionsEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionsEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionsEntry_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StartingRotationEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: false),
                    RosterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartingRotationEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartingRotationEntry_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartingRotationEntry_Roster_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Roster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BullpenEntry_PlayerId",
                table: "BullpenEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_BullpenEntry_RosterId",
                table: "BullpenEntry",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AbilityScoresId",
                table: "Players",
                column: "AbilityScoresId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerEntry_PlayerId",
                table: "PositionPlayerEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerEntry_RosterId",
                table: "PositionPlayerEntry",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionsEntry_PlayerId",
                table: "PositionsEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingRotationEntry_PlayerId",
                table: "StartingRotationEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StartingRotationEntry_RosterId",
                table: "StartingRotationEntry",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RosterId",
                table: "Teams",
                column: "RosterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BullpenEntry");

            migrationBuilder.DropTable(
                name: "PositionPlayerEntry");

            migrationBuilder.DropTable(
                name: "PositionsEntry");

            migrationBuilder.DropTable(
                name: "StartingRotationEntry");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Roster");

            migrationBuilder.DropTable(
                name: "AbilityScores");
        }
    }
}
