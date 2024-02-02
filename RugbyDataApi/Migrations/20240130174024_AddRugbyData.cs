using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RugbyDataApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRugbyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SrCompetitionId = table.Column<string>(type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Year = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SrCompetitorId = table.Column<string>(type: "TEXT", nullable: true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SrSportEventId = table.Column<string>(type: "TEXT", nullable: true),
                    RoundNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    HomeScore = table.Column<int>(type: "INTEGER", nullable: true),
                    AwayScore = table.Column<int>(type: "INTEGER", nullable: true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.FixtureId);
                    table.ForeignKey(
                        name: "FK_Fixtures_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SrPlayerId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamLineups",
                columns: table => new
                {
                    TeamLineupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Designation = table.Column<string>(type: "TEXT", nullable: true),
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLineups", x => x.TeamLineupId);
                    table.ForeignKey(
                        name: "FK_TeamLineups_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "FixtureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLineups_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersStatistics",
                columns: table => new
                {
                    PlayerStatisticsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tries = table.Column<int>(type: "INTEGER", nullable: true),
                    TryAssists = table.Column<int>(type: "INTEGER", nullable: true),
                    Conversions = table.Column<int>(type: "INTEGER", nullable: true),
                    PenaltyGoals = table.Column<int>(type: "INTEGER", nullable: true),
                    DropGoals = table.Column<int>(type: "INTEGER", nullable: true),
                    MetersRun = table.Column<int>(type: "INTEGER", nullable: true),
                    Carries = table.Column<int>(type: "INTEGER", nullable: true),
                    Passes = table.Column<int>(type: "INTEGER", nullable: true),
                    Offloads = table.Column<int>(type: "INTEGER", nullable: true),
                    CleanBreaks = table.Column<int>(type: "INTEGER", nullable: true),
                    LineoutsWon = table.Column<int>(type: "INTEGER", nullable: true),
                    LineoutsLost = table.Column<int>(type: "INTEGER", nullable: true),
                    Tackles = table.Column<int>(type: "INTEGER", nullable: true),
                    TacklesMissed = table.Column<int>(type: "INTEGER", nullable: true),
                    ScrumsWon = table.Column<int>(type: "INTEGER", nullable: true),
                    ScrumsLost = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalScrums = table.Column<int>(type: "INTEGER", nullable: true),
                    TurnoversWon = table.Column<int>(type: "INTEGER", nullable: true),
                    PenaltiesConceded = table.Column<int>(type: "INTEGER", nullable: true),
                    YellowCards = table.Column<int>(type: "INTEGER", nullable: true),
                    RedCards = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStatistics", x => x.PlayerStatisticsId);
                    table.ForeignKey(
                        name: "FK_PlayersStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "FixtureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLineups",
                columns: table => new
                {
                    PlayerLineupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SrPlayerId = table.Column<string>(type: "TEXT", nullable: true),
                    JerseyNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamLineupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLineups", x => x.PlayerLineupId);
                    table.ForeignKey(
                        name: "FK_PlayerLineups_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerLineups_TeamLineups_TeamLineupId",
                        column: x => x.TeamLineupId,
                        principalTable: "TeamLineups",
                        principalColumn: "TeamLineupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_CompetitionId",
                table: "Fixtures",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLineups_PlayerId",
                table: "PlayerLineups",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLineups_TeamLineupId",
                table: "PlayerLineups",
                column: "TeamLineupId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_FixtureId",
                table: "PlayersStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_PlayerId",
                table: "PlayersStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLineups_FixtureId",
                table: "TeamLineups",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLineups_TeamId",
                table: "TeamLineups",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerLineups");

            migrationBuilder.DropTable(
                name: "PlayersStatistics");

            migrationBuilder.DropTable(
                name: "TeamLineups");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
