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
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    Year = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(name: "Start_Date", type: "TEXT", nullable: true),
                    EndDate = table.Column<DateOnly>(name: "End_Date", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true),
                    ClubName = table.Column<string>(name: "Club_Name", type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    MatchDayTeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(name: "Start_Date", type: "TEXT", nullable: true),
                    EndDate = table.Column<DateOnly>(name: "End_Date", type: "TEXT", nullable: true),
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClubsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Club_ClubsId",
                        column: x => x.ClubsId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competition_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitionRound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    RoundNumber = table.Column<int>(name: "Round_Number", type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateOnly>(name: "Start_Date", type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(name: "End_Date", type: "TEXT", nullable: false),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionRound_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitionGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    Venue = table.Column<string>(type: "TEXT", nullable: true),
                    HomeScore = table.Column<string>(name: "Home_Score", type: "TEXT", nullable: true),
                    AwayScore = table.Column<int>(name: "Away_Score", type: "INTEGER", nullable: true),
                    CompetitionRoundId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionGame_CompetitionRound_CompetitionRoundId",
                        column: x => x.CompetitionRoundId,
                        principalTable: "CompetitionRound",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetitionGame_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchDayTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    CompetitionGameId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDayTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchDayTeam_CompetitionGame_CompetitionGameId",
                        column: x => x.CompetitionGameId,
                        principalTable: "CompetitionGame",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(name: "First_Name", type: "TEXT", nullable: true),
                    LastName = table.Column<string>(name: "Last_Name", type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    JerseyNumber = table.Column<string>(name: "Jersey_Number", type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<string>(type: "TEXT", nullable: true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true),
                    MatchDayTeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_MatchDayTeam_MatchDayTeamId",
                        column: x => x.MatchDayTeamId,
                        principalTable: "MatchDayTeam",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    CompetitionGameId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStatistics_CompetitionGame_CompetitionGameId",
                        column: x => x.CompetitionGameId,
                        principalTable: "CompetitionGame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatchStatistics_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_MatchDayTeamId",
                table: "Club",
                column: "MatchDayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_ClubsId",
                table: "Competition",
                column: "ClubsId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_SeasonId",
                table: "Competition",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionGame_CompetitionId",
                table: "CompetitionGame",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionGame_CompetitionRoundId",
                table: "CompetitionGame",
                column: "CompetitionRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRound_CompetitionId",
                table: "CompetitionRound",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDayTeam_CompetitionGameId",
                table: "MatchDayTeam",
                column: "CompetitionGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubId",
                table: "Player",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_MatchDayTeamId",
                table: "Player",
                column: "MatchDayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStatistics_CompetitionGameId",
                table: "PlayerMatchStatistics",
                column: "CompetitionGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStatistics_PlayerId",
                table: "PlayerMatchStatistics",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_MatchDayTeam_MatchDayTeamId",
                table: "Club",
                column: "MatchDayTeamId",
                principalTable: "MatchDayTeam",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_MatchDayTeam_MatchDayTeamId",
                table: "Club");

            migrationBuilder.DropTable(
                name: "PlayerMatchStatistics");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "MatchDayTeam");

            migrationBuilder.DropTable(
                name: "CompetitionGame");

            migrationBuilder.DropTable(
                name: "CompetitionRound");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Season");
        }
    }
}
