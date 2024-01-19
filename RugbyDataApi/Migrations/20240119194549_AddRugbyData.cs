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
                name: "Competition",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarCompetitionId = table.Column<string>(name: "SportRadar_Competition_Id", type: "TEXT", nullable: true),
                    CompetitionName = table.Column<string>(name: "Competition_Name", type: "TEXT", nullable: true),
                    Year = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<string>(name: "Start_Date", type: "TEXT", nullable: true),
                    EndDate = table.Column<string>(name: "End_Date", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Fixture",
                columns: table => new
                {
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    RoundNumber = table.Column<int>(name: "Round_Number", type: "INTEGER", nullable: false),
                    FixtureDate = table.Column<string>(name: "Fixture_Date", type: "TEXT", nullable: false),
                    StartTime = table.Column<string>(name: "Start_Time", type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    HomeTeam = table.Column<string>(name: "Home_Team", type: "TEXT", nullable: true),
                    AwayTeam = table.Column<string>(name: "Away_Team", type: "TEXT", nullable: true),
                    HomeScore = table.Column<int>(name: "Home_Score", type: "INTEGER", nullable: true),
                    AwayScore = table.Column<int>(name: "Away_Score", type: "INTEGER", nullable: true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.FixtureId);
                    table.ForeignKey(
                        name: "FK_Fixture_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarCompetitorId = table.Column<string>(name: "SportRadar_Competitor_Id", type: "TEXT", nullable: true),
                    ClubName = table.Column<string>(name: "Club_Name", type: "TEXT", nullable: true),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false),
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                    table.ForeignKey(
                        name: "FK_Club_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Club_Fixture_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixture",
                        principalColumn: "FixtureId");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(name: "First_Name", type: "TEXT", nullable: true),
                    LastName = table.Column<string>(name: "Last_Name", type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    JerseyNumber = table.Column<string>(name: "Jersey_Number", type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<string>(type: "TEXT", nullable: true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureStatistics",
                columns: table => new
                {
                    FixtureStatisticsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SportRadarId = table.Column<string>(name: "SportRadar_Id", type: "TEXT", nullable: true),
                    Tries = table.Column<int>(type: "INTEGER", nullable: true),
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
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    FixtureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureStatistics", x => x.FixtureStatisticsId);
                    table.ForeignKey(
                        name: "FK_FixtureStatistics_Fixture_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixture",
                        principalColumn: "FixtureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixtureStatistics_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_CompetitionId",
                table: "Club",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_FixtureId",
                table: "Club",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixture_CompetitionId",
                table: "Fixture",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureStatistics_FixtureId",
                table: "FixtureStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureStatistics_PlayerId",
                table: "FixtureStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubId",
                table: "Player",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixtureStatistics");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Fixture");

            migrationBuilder.DropTable(
                name: "Competition");
        }
    }
}
