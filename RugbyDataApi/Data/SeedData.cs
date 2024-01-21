using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;

namespace RugbyDataApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RugbyDataDbContext(serviceProvider.GetRequiredService<DbContextOptions<RugbyDataDbContext>>()))
            {

                // ************************************

                // Look for any competitions.
                if (!context.Competitions.Any())
                {
                    // Create sample competitions
                    var competitions = new List<Competition>
                    {
                        new Competition
                        {
                            CompetitionId = 1,
                            SportRadar_Competition_Id = "sr:competition:401",
                            Year = "23/24",
                            Competition_Name = "European Rugby Champions Cup",
                            Start_Date = "2023-12-08",
                            End_Date = "2024-05-25",
    
                        },
                        new Competition
                        {
                            CompetitionId = 2,
                            SportRadar_Competition_Id = "sr:competition:419",
                            Year = "23/24",
                            Competition_Name = "United Rugby Championship",
                            Start_Date = "2023-10-21",
                            End_Date = "2024-06-22",
    
                        },
                        new Competition
                        {
                            CompetitionId = 3,
                            SportRadar_Competition_Id = "sr:competition:752",
                            Year = "23/24",
                            Competition_Name = "European Challenge Cup",
                            Start_Date = "2023-12-08",
                            End_Date = "2024-05-24",
    
                        },
                    };

                    context.Competitions.AddRange(competitions);
                }
                context.SaveChanges();                
                // ************************************

                // Look for any clubs.
                if (!context.Clubs.Any())
                {
                    // Create sample clubs
                    var clubs = new List<Club>
                    {
                        new Club
                        {
                            ClubId = 1,
                            SportRadar_Competitor_Id = "sr:competitor:4203",
                            Club_Name = "Munster",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 2,
                            SportRadar_Competitor_Id = "sr:competitor:4210",
                            Club_Name = "Leinster",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 3,
                            SportRadar_Competitor_Id = "sr:competitor:8083",
                            Club_Name = "Connacht Rugby",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 4,
                            SportRadar_Competitor_Id = "sr:competitor:4211",
                            Club_Name = "Ulster Rugby",
                            CompetitionId = 2
                        },
                        // Add more sample clubs as needed
                    };

                    context.Clubs.AddRange(clubs);
                }
                context.SaveChanges();


                // ************************************

                // Look for any Competition fixtures.
                if (!context.Fixtures.Any())
                {
                    // Create sample competition fixtures
                    var fixtures = new List<Fixture>
                    {
                        new Fixture // Data from: SportRadar Api / Season Lineups Endpoint:
                        {
                            FixtureId = 1,
                            SportRadar_Id = "sr:sport_event:42404663", // Ref: sport_event > id
                            Round_Number = 4, // Ref: sport_event > sport_event_context > round
                            Fixture_Date = "2023-11-10", // Ref: sport_event > start_time
                            Start_Time = "19:35:00+00:00", // Ref: sport_event > start_time
                            Status = "closed", // Ref: sport_event > Sport_Event_Status
                            Home_Team = "Ulster Rugby", // Ref: sport_event > sport_event_context > competitors
                            Away_Team = "Munster", // Ref: sport_event > sport_event_context > competitors
                            Home_Score = 21, // Ref: sport_event > Sport_Event_Status
                            Away_Score = 14, // Ref: sport_event > Sport_Event_Status
                            CompetitionId = 2, // URC -> Same ID as Competitions SeedData
                        },
                        new Fixture
                        {
                            FixtureId = 2,
                            SportRadar_Id = "sr:sport_event:42404701", // Ref: sport_event > id
                            Round_Number = 6, // Ref: sport_event > sport_event_context > round
                            Fixture_Date = "2023-11-25", // Ref: sport_event > start_time
                            Start_Time = "18:30:00+00:00", // Ref: sport_event > start_time
                            Status = "closed", // Ref: sport_event > Sport_Event_Status
                            Home_Team = "Leinster", // Ref: sport_event > sport_event_context > competitors
                            Away_Team = "Munster", // Ref: sport_event > sport_event_context > competitors
                            Home_Score = 21, // Ref: sport_event > Sport_Event_Status
                            Away_Score = 16, // Ref: sport_event > Sport_Event_Status
                            CompetitionId = 2, // URC -> Same ID as Competitions SeedData
                        },
                        new Fixture
                        {
                            FixtureId = 3,
                            SportRadar_Id = "sr:sport_event:42404735", // Ref: sport_event > id
                            Round_Number = 8, // Ref: sport_event > sport_event_context > round
                            Fixture_Date = "2023-12-26", // Ref: sport_event > start_time
                            Start_Time = "19:35:00+00:00", // Ref: sport_event > start_time
                            Status = "closed", // Ref: sport_event > Sport_Event_Status
                            Home_Team = "Munster", // Ref: sport_event > sport_event_context > competitors
                            Away_Team = "Leinster", // Ref: sport_event > sport_event_context > competitors
                            Home_Score = 3, // Ref: sport_event > Sport_Event_Status
                            Away_Score = 9, // Ref: sport_event > Sport_Event_Status
                            CompetitionId = 2, // URC -> Same ID as Competitions SeedData
                        },
                        new Fixture
                        {
                            FixtureId = 4,
                            SportRadar_Id = "sr:sport_event:42404745", // Ref: sport_event > id
                            Round_Number = 9, // Ref: sport_event > sport_event_context > round
                            Fixture_Date = "2024-01-01", // Ref: sport_event > start_time
                            Start_Time = "15:00:00+00:00", // Ref: sport_event > start_time
                            Status = "closed", // Ref: sport_event > Sport_Event_Status
                            Home_Team = "Connacht Rugby", // Ref: sport_event > sport_event_context > competitors
                            Away_Team = "Munster", // Ref: sport_event > sport_event_context > competitors
                            Home_Score = 22, // Ref: sport_event > Sport_Event_Status
                            Away_Score = 9, // Ref: sport_event > Sport_Event_Status
                            CompetitionId = 2, // URC -> Same ID as Competitions SeedData
                        },
                    };

                    context.Fixtures.AddRange(fixtures);
                }
                context.SaveChanges();
                // ************************************

                // Look for any Player.
                if (!context.Players.Any())
                {
                    // Create sample players
                    var players = new List<Player>
                    {
                        new Player // Obtain from Sport Radar Api > Season Players Endpoint
                        {
                            PlayerId = 1,
                            SportRadar_Id = "sr:player:2079939",
                            First_Name = "Jack",
                            Last_Name = "Crowley",
                            Nationality = "Ireland",
                            Position = "Forward", //Remove
                            Jersey_Number = "10",
                            Age = "25", //remove
                            // add height
                            Weight = "91", //int
                            ClubId = 2
                        },
                        // Add more sample players as needed
                    };

                    context.Players.AddRange(players);
                }
                context.SaveChanges();
                // ************************************

                // Look for any Player Match Statistics.
                if (!context.FixturesStatistics.Any())
                {
                    // Create sample player match statistics
                    var fixturesStatistics = new List<FixtureStatistics>
                    {
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 1,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 2,
                            Try_Assists = 2,
                            Conversions = 2,
                            Penalty_Goals = 1,
                            Drop_Goals = 1,
                            Meters_Run = 80,
                            Carries = 15,
                            Passes = 20,
                            Offloads = 3,
                            Clean_Breaks = 2,
                            Lineouts_Won = 0,
                            Lineouts_Lost = 0,
                            Tackles = 5,
                            Tackles_Missed = 1,
                            Scrums_Won = 0,
                            Scrums_Lost = 0,
                            Total_Scrums = 0,
                            Turnovers_Won = 0,
                            Penalties_Conceded = 1,
                            Yellow_Cards = 0,
                            Red_Cards = 0,
                            PlayerId = 1,
                            FixtureId = 1,
                        },
                        // new FixtureStatistics
                        // {
                        //     FixtureStatisticsId = 2,
                        //     SportRadar_Id = "sr:statistics:001",
                        //     Tries = 2,
                        //     Try_Assists = 2,
                        //     Conversions = 2,
                        //     Penalty_Goals = 1,
                        //     Drop_Goals = 1,
                        //     Meters_Run = 80,
                        //     Carries = 15,
                        //     Passes = 20,
                        //     Offloads = 3,
                        //     Clean_Breaks = 2,
                        //     Lineouts_Won = 0,
                        //     Lineouts_Lost = 0,
                        //     Tackles = 5,
                        //     Tackles_Missed = 1,
                        //     Scrums_Won = 0,
                        //     Scrums_Lost = 0,
                        //     Total_Scrums = 0,
                        //     Turnovers_Won = 0,
                        //     Penalties_Conceded = 1,
                        //     Yellow_Cards = 0,
                        //     Red_Cards = 0,
                        //     PlayerId = 1,
                        //     FixtureId = 2,
                        // },
                        // new FixtureStatistics
                        // {
                        //     FixtureStatisticsId = 3,
                        //     SportRadar_Id = "sr:statistics:001",
                        //     Tries = 2,
                        //     Try_Assists = 2,
                        //     Conversions = 2,
                        //     Penalty_Goals = 1,
                        //     Drop_Goals = 1,
                        //     Meters_Run = 80,
                        //     Carries = 15,
                        //     Passes = 20,
                        //     Offloads = 3,
                        //     Clean_Breaks = 2,
                        //     Lineouts_Won = 0,
                        //     Lineouts_Lost = 0,
                        //     Tackles = 5,
                        //     Tackles_Missed = 1,
                        //     Scrums_Won = 0,
                        //     Scrums_Lost = 0,
                        //     Total_Scrums = 0,
                        //     Turnovers_Won = 0,
                        //     Penalties_Conceded = 1,
                        //     Yellow_Cards = 0,
                        //     Red_Cards = 0,
                        //     PlayerId = 1,
                        //     FixtureId = 3,
                        // },
                        // Add more sample player match statistics as needed
                    };

                    context.FixturesStatistics.AddRange(fixturesStatistics);
                }
                context.SaveChanges();
            }
        }
    }
}