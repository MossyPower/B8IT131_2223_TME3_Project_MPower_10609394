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
            migrationBuilder.RenameColumn(
                name: "Competition_Id",
                table: "Seasons",
                newName: "SportRadar_Id");

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true),
                    ClubName = table.Column<string>(name: "Club_Name", type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    MatchDayTeamId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(name: "Start_Date", type: "TEXT", nullable: true),
                    EndDate = table.Column<DateOnly>(name: "End_Date", type: "TEXT", nullable: true),
                    SeasonId = table.Column<string>(type: "TEXT", nullable: true),
                    ClubsId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Club_ClubsId",
                        column: x => x.ClubsId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competitions_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitionRounds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    RoundNumber = table.Column<int>(name: "Round_Number", type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(name: "Start_Date", type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(name: "End_Date", type: "TEXT", nullable: false),
                    CompetitionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionRounds_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitionGames",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    Venue = table.Column<string>(type: "TEXT", nullable: true),
                    HomeScore = table.Column<string>(name: "Home_Score", type: "TEXT", nullable: true),
                    AwayScore = table.Column<int>(name: "Away_Score", type: "INTEGER", nullable: true),
                    CompetitionRoundId = table.Column<string>(type: "TEXT", nullable: true),
                    CompetitionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionGames_CompetitionRounds_CompetitionRoundId",
                        column: x => x.CompetitionRoundId,
                        principalTable: "CompetitionRounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetitionGames_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchDayTeams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionGameId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDayTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchDayTeams_CompetitionGames_CompetitionGameId",
                        column: x => x.CompetitionGameId,
                        principalTable: "CompetitionGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(name: "First_Name", type: "TEXT", nullable: true),
                    LastName = table.Column<string>(name: "Last_Name", type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    JerseyNumber = table.Column<string>(name: "Jersey_Number", type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<string>(type: "TEXT", nullable: true),
                    ClubId = table.Column<string>(type: "TEXT", nullable: true),
                    MatchDayTeamId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_MatchDayTeams_MatchDayTeamId",
                        column: x => x.MatchDayTeamId,
                        principalTable: "MatchDayTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayersMatchStatistics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    Tries = table.Column<string>(type: "TEXT", nullable: true),
                    TryAssists = table.Column<int>(name: "Try_Assists", type: "INTEGER", nullable: true),
                    Conversions = table.Column<int>(type: "INTEGER", nullable: true),
                    PenaltyGoals = table.Column<int>(name: "Penalty_Goals", type: "INTEGER", nullable: true),
                    DropGoals = table.Column<int>(name: "Drop_Goals", type: "INTEGER", nullable: true),
                    BallPossessition = table.Column<int>(name: "Ball_Possessition", type: "INTEGER", nullable: true),
                    MetersRun = table.Column<int>(name: "Meters_Run", type: "INTEGER", nullable: true),
                    Carries = table.Column<int>(type: "INTEGER", nullable: true),
                    Passes = table.Column<int>(type: "INTEGER", nullable: true),
                    Offloads = table.Column<int>(type: "INTEGER", nullable: true),
                    CleanBreaks = table.Column<int>(name: "Clean_Breaks", type: "INTEGER", nullable: true),
                    LineoutsWon = table.Column<int>(name: "Lineouts_Won", type: "INTEGER", nullable: true),
                    LineoutsLost = table.Column<int>(name: "Lineouts_Lost", type: "INTEGER", nullable: true),
                    Tackles = table.Column<int>(type: "INTEGER", nullable: true),
                    TacklesMissed = table.Column<int>(name: "Tackles_Missed", type: "INTEGER", nullable: true),
                    ScrumsWon = table.Column<int>(name: "Scrums_Won", type: "INTEGER", nullable: true),
                    ScrumsLost = table.Column<int>(name: "Scrums_Lost", type: "INTEGER", nullable: true),
                    TotalScrums = table.Column<int>(name: "Total_Scrums", type: "INTEGER", nullable: true),
                    TurnoversWon = table.Column<int>(name: "Turnovers_Won", type: "INTEGER", nullable: true),
                    PenaltiesConceded = table.Column<int>(name: "Penalties_Conceded", type: "INTEGER", nullable: true),
                    YellowCards = table.Column<int>(name: "Yellow_Cards", type: "INTEGER", nullable: true),
                    RedCards = table.Column<int>(name: "Red_Cards", type: "INTEGER", nullable: true),
                    CompetitionGameId = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersMatchStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersMatchStatistics_CompetitionGames_CompetitionGameId",
                        column: x => x.CompetitionGameId,
                        principalTable: "CompetitionGames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersMatchStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_MatchDayTeamId",
                table: "Club",
                column: "MatchDayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionGames_CompetitionId",
                table: "CompetitionGames",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionGames_CompetitionRoundId",
                table: "CompetitionGames",
                column: "CompetitionRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRounds_CompetitionId",
                table: "CompetitionRounds",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_ClubsId",
                table: "Competitions",
                column: "ClubsId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_SeasonId",
                table: "Competitions",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDayTeams_CompetitionGameId",
                table: "MatchDayTeams",
                column: "CompetitionGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_MatchDayTeamId",
                table: "Players",
                column: "MatchDayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersMatchStatistics_CompetitionGameId",
                table: "PlayersMatchStatistics",
                column: "CompetitionGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersMatchStatistics_PlayerId",
                table: "PlayersMatchStatistics",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_MatchDayTeams_MatchDayTeamId",
                table: "Club",
                column: "MatchDayTeamId",
                principalTable: "MatchDayTeams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_MatchDayTeams_MatchDayTeamId",
                table: "Club");

            migrationBuilder.DropTable(
                name: "PlayersMatchStatistics");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "MatchDayTeams");

            migrationBuilder.DropTable(
                name: "CompetitionGames");

            migrationBuilder.DropTable(
                name: "CompetitionRounds");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.RenameColumn(
                name: "SportRadar_Id",
                table: "Seasons",
                newName: "Competition_Id");
        }
    }
}
