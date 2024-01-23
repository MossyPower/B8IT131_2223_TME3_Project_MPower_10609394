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
                    // Create sample competitions (Use URC, Premiership and Champions Cup as examples)
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
                    // Create sample clubs (use URC as example)
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
                        new Club
                        {
                            ClubId = 5,
                            SportRadar_Competitor_Id = "sr:competitor:4184",
                            Club_Name = "Lions",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 6,
                            SportRadar_Competitor_Id = "sr:competitor:4187",
                            Club_Name = "The Sharks",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 7,
                            SportRadar_Competitor_Id = "sr:competitor:4188",
                            Club_Name = "Stormers",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 8,
                            SportRadar_Competitor_Id = "sr:competitor:4205",
                            Club_Name = "Scarlets",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 9,
                            SportRadar_Competitor_Id = "sr:competitor:4206",
                            Club_Name = "Edinburgh Rugby",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 10,
                            SportRadar_Competitor_Id = "sr:competitor:4214",
                            Club_Name = "Glasgow Warriors",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 11,
                            SportRadar_Competitor_Id = "sr:competitor:4215",
                            Club_Name = "Cardiff Rugby",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 12,
                            SportRadar_Competitor_Id = "sr:competitor:8082",
                            Club_Name = "Ospreys",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 13,
                            SportRadar_Competitor_Id = "sr:competitor:8084",
                            Club_Name = "Dragons",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 14,
                            SportRadar_Competitor_Id = "sr:competitor:21798",
                            Club_Name = "Benetton Treviso",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 15,
                            SportRadar_Competitor_Id = "sr:competitor:75331",
                            Club_Name = "Zebre",
                            CompetitionId = 2
                        },
                        new Club
                        {
                            ClubId = 16,
                            SportRadar_Competitor_Id = "sr:competitor:312136",
                            Club_Name = "Bulls",
                            CompetitionId = 2
                        },
                    };

                    context.Clubs.AddRange(clubs);
                }
                context.SaveChanges();


                // ************************************

                // Look for any Competition fixtures.
                if (!context.Fixtures.Any())
                {
                    // Create sample competition fixtures (Use all fixtures from round 1 of the URC as an example)
                    var fixtures = new List<Fixture>
                    {
                        new Fixture // Data from: SportRadar Api / Season Lineups Endpoint:
                        {
                            FixtureId = 1,
                            SportRadar_Id = "sr:sport_event:42404611",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "12:00:00+00:00",
                            Status = "closed",
                            Home_Team = "Zebre",
                            Away_Team = "Ulster Rugby",
                            Home_Score = 36,
                            Away_Score = 40,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 2,
                            SportRadar_Id = "sr:sport_event:42404613",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "14:00:00+00:00",
                            Status = "closed",
                            Home_Team = "Connacht Rugby",
                            Away_Team = "Ospreys",
                            Home_Score = 34,
                            Away_Score = 26,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 3,
                            SportRadar_Id = "sr:sport_event:42404615",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "14:05:00+00:00",
                            Status = "closed",
                            Home_Team = "Lions",
                            Away_Team = "Stormers",
                            Home_Score = 33,
                            Away_Score = 35,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 4,
                            SportRadar_Id = "sr:sport_event:42404617",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "14:05:00+00:00",
                            Status = "closed",
                            Home_Team = "Dragons",
                            Away_Team = "Edinburgh Rugby",
                            Home_Score = 17,
                            Away_Score = 22,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 5,
                            SportRadar_Id = "sr:sport_event:42404619",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "16:15:00+00:00",
                            Status = "closed",
                            Home_Team = "Cardiff Rugby",
                            Away_Team = "Benetton Treviso",
                            Home_Score = 22,
                            Away_Score = 23,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 6,
                            SportRadar_Id = "sr:sport_event:42404621",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-21",
                            Start_Time = "16:15:00+00:00",
                            Status = "closed",
                            Home_Team = "Munster",
                            Away_Team = "The Sharks",
                            Home_Score = 34,
                            Away_Score = 21,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 7,
                            SportRadar_Id = "sr:sport_event:42404623",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-22",
                            Start_Time = "13:00:00+00:00",
                            Status = "closed",
                            Home_Team = "Bulls",
                            Away_Team = "Scarlets",
                            Home_Score = 63,
                            Away_Score = 21,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 8,
                            SportRadar_Id = "sr:sport_event:42404625",
                            Round_Number = 1,
                            Fixture_Date = "2023-10-22",
                            Start_Time = "15:00:00+00:00",
                            Status = "closed",
                            Home_Team = "Glasgow Warriors",
                            Away_Team = "Leinster",
                            Home_Score = 43,
                            Away_Score = 25,
                            CompetitionId = 2,
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
                            Tries = 1,
                            Try_Assists = 1,
                            Conversions = 1,
                            Penalty_Goals = 1,
                            Drop_Goals = 1,
                            Meters_Run = 1,
                            Carries = 1,
                            Passes = 1,
                            Offloads = 1,
                            Clean_Breaks = 1,
                            Lineouts_Won = 1,
                            Lineouts_Lost = 1,
                            Tackles = 1,
                            Tackles_Missed = 1,
                            Scrums_Won = 1,
                            Scrums_Lost = 1,
                            Total_Scrums = 1,
                            Turnovers_Won = 1,
                            Penalties_Conceded = 1,
                            Yellow_Cards = 1,
                            Red_Cards = 1,
                            PlayerId = 1,
                            FixtureId = 1,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 2,
                            SportRadar_Id = "sr:statistics:002",
                            Tries = 2,
                            Try_Assists = 2,
                            Conversions = 2,
                            Penalty_Goals = 2,
                            Drop_Goals = 2,
                            Meters_Run = 2,
                            Carries = 2,
                            Passes = 2,
                            Offloads = 2,
                            Clean_Breaks = 2,
                            Lineouts_Won = 2,
                            Lineouts_Lost = 2,
                            Tackles = 2,
                            Tackles_Missed = 2,
                            Scrums_Won = 2,
                            Scrums_Lost = 2,
                            Total_Scrums = 2,
                            Turnovers_Won = 2,
                            Penalties_Conceded = 2,
                            Yellow_Cards = 2,
                            Red_Cards = 2,
                            PlayerId = 1,
                            FixtureId = 2,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 3,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 3,
                            Try_Assists = 3,
                            Conversions = 3,
                            Penalty_Goals = 3,
                            Drop_Goals = 3,
                            Meters_Run = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            Clean_Breaks = 3,
                            Lineouts_Won = 3,
                            Lineouts_Lost = 3,
                            Tackles = 53,
                            Tackles_Missed = 3,
                            Scrums_Won = 3,
                            Scrums_Lost = 3,
                            Total_Scrums = 3,
                            Turnovers_Won = 3,
                            Penalties_Conceded = 3,
                            Yellow_Cards = 3,
                            Red_Cards = 3,
                            PlayerId = 1,
                            FixtureId = 3,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 4,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 4,
                            Try_Assists = 4,
                            Conversions = 4,
                            Penalty_Goals = 4,
                            Drop_Goals = 4,
                            Meters_Run = 4,
                            Carries = 4,
                            Passes = 4,
                            Offloads = 4,
                            Clean_Breaks = 4,
                            Lineouts_Won = 4,
                            Lineouts_Lost = 4,
                            Tackles = 4,
                            Tackles_Missed = 4,
                            Scrums_Won = 4,
                            Scrums_Lost = 4,
                            Total_Scrums = 4,
                            Turnovers_Won = 4,
                            Penalties_Conceded = 4,
                            Yellow_Cards = 4,
                            Red_Cards = 4,
                            PlayerId = 1,
                            FixtureId = 4,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 5,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 3,
                            Try_Assists = 3,
                            Conversions = 3,
                            Penalty_Goals = 3,
                            Drop_Goals = 3,
                            Meters_Run = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            Clean_Breaks = 3,
                            Lineouts_Won = 3,
                            Lineouts_Lost = 3,
                            Tackles = 53,
                            Tackles_Missed = 3,
                            Scrums_Won = 3,
                            Scrums_Lost = 3,
                            Total_Scrums = 3,
                            Turnovers_Won = 3,
                            Penalties_Conceded = 3,
                            Yellow_Cards = 3,
                            Red_Cards = 3,
                            PlayerId = 1,
                            FixtureId = 5,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 6,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 3,
                            Try_Assists = 3,
                            Conversions = 3,
                            Penalty_Goals = 3,
                            Drop_Goals = 3,
                            Meters_Run = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            Clean_Breaks = 3,
                            Lineouts_Won = 3,
                            Lineouts_Lost = 3,
                            Tackles = 53,
                            Tackles_Missed = 3,
                            Scrums_Won = 3,
                            Scrums_Lost = 3,
                            Total_Scrums = 3,
                            Turnovers_Won = 3,
                            Penalties_Conceded = 3,
                            Yellow_Cards = 3,
                            Red_Cards = 3,
                            PlayerId = 1,
                            FixtureId = 6,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 7,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 3,
                            Try_Assists = 3,
                            Conversions = 3,
                            Penalty_Goals = 3,
                            Drop_Goals = 3,
                            Meters_Run = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            Clean_Breaks = 3,
                            Lineouts_Won = 3,
                            Lineouts_Lost = 3,
                            Tackles = 53,
                            Tackles_Missed = 3,
                            Scrums_Won = 3,
                            Scrums_Lost = 3,
                            Total_Scrums = 3,
                            Turnovers_Won = 3,
                            Penalties_Conceded = 3,
                            Yellow_Cards = 3,
                            Red_Cards = 3,
                            PlayerId = 1,
                            FixtureId = 7,
                        },
                        new FixtureStatistics
                        {
                            FixtureStatisticsId = 8,
                            SportRadar_Id = "sr:statistics:001",
                            Tries = 3,
                            Try_Assists = 3,
                            Conversions = 3,
                            Penalty_Goals = 3,
                            Drop_Goals = 3,
                            Meters_Run = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            Clean_Breaks = 3,
                            Lineouts_Won = 3,
                            Lineouts_Lost = 3,
                            Tackles = 53,
                            Tackles_Missed = 3,
                            Scrums_Won = 3,
                            Scrums_Lost = 3,
                            Total_Scrums = 3,
                            Turnovers_Won = 3,
                            Penalties_Conceded = 3,
                            Yellow_Cards = 3,
                            Red_Cards = 3,
                            PlayerId = 1,
                            FixtureId = 8,
                        },
                        // Add more sample player match statistics as needed
                    };

                    context.FixturesStatistics.AddRange(fixturesStatistics);
                }
                context.SaveChanges();
            }
        }
    }
}