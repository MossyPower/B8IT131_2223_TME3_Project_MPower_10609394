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
                            SrCompetitionId = "sr:competition:401",
                            CompetitionName = "European Rugby Champions Cup",
                            StartDate = new DateTime(2023,12,8),
                            EndDate = new DateTime(2024, 5, 25),
                            Year = "23/24",
                        },
                        new Competition
                        {
                            CompetitionId = 2,
                            SrCompetitionId = "sr:competition:419",
                            CompetitionName = "United Rugby Championship",
                            StartDate = new DateTime(2023,10,21),
                            EndDate = new DateTime(2024,6,22),
                            Year = "23/24",
    
                        },
                        new Competition
                        {
                            CompetitionId = 3,
                            SrCompetitionId = "sr:competition:752",
                            CompetitionName = "European Challenge Cup",
                            StartDate = new DateTime(2023,12,8),
                            EndDate = new DateTime(2024,5,24),
                            Year = "23/24",
    
                        },
                    };

                    context.Competitions.AddRange(competitions);
                }
                context.SaveChanges();                
                // ************************************

                // Look for any clubs.
                if (!context.Teams.Any())
                {
                    // Create sample clubs (use URC as example)
                    var teams = new List<Team>
                    {
                        new Team
                        {
                            TeamId = 1,
                            SrCompetitorId = "sr:competitor:4203",
                            TeamName = "Munster",
                            Country = "Ireland",
                        },
                        new Team
                        {
                            TeamId = 2,
                            SrCompetitorId = "sr:competitor:4210",
                            TeamName = "Leinster",
                            Country = "Ireland",
                        },
                        new Team
                        {
                            TeamId = 3,
                            SrCompetitorId = "sr:competitor:8083",
                            TeamName = "Connacht Rugby",
                            Country = "Ireland",
                        },
                        new Team
                        {
                            TeamId = 4,
                            SrCompetitorId = "sr:competitor:4211",
                            TeamName = "Ulster Rugby",
                            Country = "Ireland",
                        },
                        new Team
                        {
                            TeamId = 5,
                            SrCompetitorId = "sr:competitor:4184",
                            TeamName = "Lions",
                            Country = "South Africa",
                        },
                        new Team
                        {
                            TeamId = 6,
                            SrCompetitorId = "sr:competitor:4187",
                            TeamName = "The Sharks",
                            Country = "South Africa",
                        },
                        new Team
                        {
                            TeamId = 7,
                            SrCompetitorId = "sr:competitor:4188",
                            TeamName = "Stormers",
                            Country = "South Africa",
                        },
                        new Team
                        {
                            TeamId = 8,
                            SrCompetitorId = "sr:competitor:4205",
                            TeamName = "Scarlets",
                            Country = "Wales",
                        },
                        new Team
                        {
                            TeamId = 9,
                            SrCompetitorId = "sr:competitor:4206",
                            TeamName = "Edinburgh Rugby",
                            Country = "Scotland",
                        },
                        new Team
                        {
                            TeamId = 10,
                            SrCompetitorId = "sr:competitor:4214",
                            TeamName = "Glasgow Warriors",
                            Country = "Scotland",
                        },
                        new Team
                        {
                            TeamId = 11,
                            SrCompetitorId = "sr:competitor:4215",
                            TeamName = "Cardiff Rugby",
                            Country = "Wales",
                        },
                        new Team
                        {
                            TeamId = 12,
                            SrCompetitorId = "sr:competitor:8082",
                            TeamName = "Ospreys",
                            Country = "Wales",
                        },
                        new Team
                        {
                            TeamId = 13,
                            SrCompetitorId = "sr:competitor:8084",
                            TeamName = "Dragons",
                            Country = "Wales",
                        },
                        new Team
                        {
                            TeamId = 14,
                            SrCompetitorId = "sr:competitor:21798",
                            TeamName = "Benetton Treviso",
                            Country = "Italy",
                        },
                        new Team
                        {
                            TeamId = 15,
                            SrCompetitorId = "sr:competitor:75331",
                            TeamName = "Zebre",
                            Country = "Italy",
                        },
                        new Team
                        {
                            TeamId = 16,
                            SrCompetitorId = "sr:competitor:312136",
                            TeamName = "Bulls",
                            Country = "South Africa",
                        },
                    };

                    context.Teams.AddRange(teams);
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
                            SrSportEventId = "sr:sport_event:42404611",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,12,00,00,00,00),
                            Status = "closed",
                            //Home_Team = "Zebre",
                            //Away_Team = "Ulster Rugby",
                            HomeScore = 36,
                            AwayScore = 40,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 2,
                            SrSportEventId = "sr:sport_event:42404613",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,14,00,00,00,00),
                            Status = "closed",
                            //Home_Team = "Connacht Rugby",
                            //Away_Team = "Ospreys",
                            HomeScore = 34,
                            AwayScore = 26,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 3,
                            SrSportEventId = "sr:sport_event:42404615",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,14,05,00,00),
                            Status = "closed",
                            //Home_Team = "Lions",
                            //Away_Team = "Stormers",
                            HomeScore = 33,
                            AwayScore = 35,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 4,
                            SrSportEventId = "sr:sport_event:42404617",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,14,05,00,00,00),
                            Status = "closed",
                            //Home_Team = "Dragons",
                            //Away_Team = "Edinburgh Rugby",
                            HomeScore = 17,
                            AwayScore = 22,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 5,
                            SrSportEventId = "sr:sport_event:42404619",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,16,15,00,00,00),
                            Status = "closed",
                           // Home_Team = "Cardiff Rugby",
                            //Away_Team = "Benetton Treviso",
                            HomeScore = 22,
                            AwayScore = 23,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 6,
                            SrSportEventId = "sr:sport_event:42404621",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,16,15,00,00,00),
                            Status = "closed",
                            //Home_Team = "Munster",
                            //Away_Team = "The Sharks",
                            HomeScore = 34,
                            AwayScore = 21,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 7,
                            SrSportEventId = "sr:sport_event:42404623",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,22,13,00,00,00,00),
                            Status = "closed",
                            //Home_Team = "Bulls",
                            //Away_Team = "Scarlets",
                            HomeScore = 63,
                            AwayScore = 21,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 8,
                            SrSportEventId = "sr:sport_event:42404625",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,22,15,00,00,00,00),
                            Status = "closed",
                            //Home_Team = "Glasgow Warriors",
                            //Away_Team = "Leinster",
                            HomeScore = 43,
                            AwayScore = 25,
                            CompetitionId = 2,
                        },
                    };

                    context.Fixtures.AddRange(fixtures);
                }
                context.SaveChanges();
                // ************************************
                
                // Look for any Team Lineup.
                if (!context.TeamLineups.Any())
                {
                    // Create sample players
                    var teamLineups = new List<TeamLineup>
                    {
                        new TeamLineup
                        {
                            TeamLineupId = 1,
                            Designation = "Home",
                            FixtureId = 1,
                            TeamId = 15,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 1,
                            Designation = "Home",
                            FixtureId = 1,
                            TeamId = 4,
                        },
                        // Add more sample players as needed
                    };
                    context.TeamLineups.AddRange(teamLineups);
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
                            SrPlayerId = "sr:player:2079939",
                            FirstName = "Jack",
                            LastName = "Crowley",
                            DateOfBirth = new DateOnly(2000,1,13),
                            Nationality = "Ireland",
                            JerseyNumber = "10",
                            TeamId = 2,
                            TeamLineupId = 1,
                        },
                        // Add more sample players as needed
                    };

                    context.Players.AddRange(players);
                }
                context.SaveChanges();
                // ************************************

                // Look for any Player Match Statistics.
                if (!context.PlayersStatistics.Any())
                {
                    // Create sample player match statistics
                    var playersStatistics = new List<PlayerStatistics>
                    {
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 1,
                            Tries = 1,
                            TryAssists = 1,
                            Conversions = 1,
                            PenaltyGoals = 1,
                            DropGoals = 1,
                            MetersRun = 1,
                            Carries = 1,
                            Passes = 1,
                            Offloads = 1,
                            CleanBreaks = 1,
                            LineoutsWon = 1,
                            LineoutsLost = 1,
                            Tackles = 1,
                            TacklesMissed = 1,
                            ScrumsWon = 1,
                            ScrumsLost = 1,
                            TotalScrums = 1,
                            TurnoversWon = 1,
                            PenaltiesConceded = 1,
                            YellowCards = 1,
                            RedCards = 1,
                            PlayerId = 1,
                            FixtureId = 1,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 2,
                            Tries = 2,
                            TryAssists = 2,
                            Conversions = 2,
                            PenaltyGoals = 2,
                            DropGoals = 2,
                            MetersRun = 2,
                            Carries = 2,
                            Passes = 2,
                            Offloads = 2,
                            CleanBreaks = 2,
                            LineoutsWon = 2,
                            LineoutsLost = 2,
                            Tackles = 2,
                            TacklesMissed = 2,
                            ScrumsWon = 2,
                            ScrumsLost = 2,
                            TotalScrums = 2,
                            TurnoversWon = 2,
                            PenaltiesConceded = 2,
                            YellowCards = 2,
                            RedCards = 2,
                            PlayerId = 1,
                            FixtureId = 2,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 3,
                            Tries = 3,
                            TryAssists = 3,
                            Conversions = 3,
                            PenaltyGoals = 3,
                            DropGoals = 3,
                            MetersRun = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            CleanBreaks = 3,
                            LineoutsWon = 3,
                            LineoutsLost = 3,
                            Tackles = 53,
                            TacklesMissed = 3,
                            ScrumsWon = 3,
                            ScrumsLost = 3,
                            TotalScrums = 3,
                            TurnoversWon = 3,
                            PenaltiesConceded = 3,
                            YellowCards = 3,
                            RedCards = 3,
                            PlayerId = 1,
                            FixtureId = 3,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 4,
                            Tries = 4,
                            TryAssists = 4,
                            Conversions = 4,
                            PenaltyGoals = 4,
                            DropGoals = 4,
                            MetersRun = 4,
                            Carries = 4,
                            Passes = 4,
                            Offloads = 4,
                            CleanBreaks = 4,
                            LineoutsWon = 4,
                            LineoutsLost = 4,
                            Tackles = 4,
                            TacklesMissed = 4,
                            ScrumsWon = 4,
                            ScrumsLost = 4,
                            TotalScrums = 4,
                            TurnoversWon = 4,
                            PenaltiesConceded = 4,
                            YellowCards = 4,
                            RedCards = 4,
                            PlayerId = 1,
                            FixtureId = 4,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 5,
                            Tries = 3,
                            TryAssists = 3,
                            Conversions = 3,
                            PenaltyGoals = 3,
                            DropGoals = 3,
                            MetersRun = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            CleanBreaks = 3,
                            LineoutsWon = 3,
                            LineoutsLost = 3,
                            Tackles = 53,
                            TacklesMissed = 3,
                            ScrumsWon = 3,
                            ScrumsLost = 3,
                            TotalScrums = 3,
                            TurnoversWon = 3,
                            PenaltiesConceded = 3,
                            YellowCards = 3,
                            RedCards = 3,
                            PlayerId = 1,
                            FixtureId = 5,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 6,
                            Tries = 3,
                            TryAssists = 3,
                            Conversions = 3,
                            PenaltyGoals = 3,
                            DropGoals = 3,
                            MetersRun = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            CleanBreaks = 3,
                            LineoutsWon = 3,
                            LineoutsLost = 3,
                            Tackles = 53,
                            TacklesMissed = 3,
                            ScrumsWon = 3,
                            ScrumsLost = 3,
                            TotalScrums = 3,
                            TurnoversWon = 3,
                            PenaltiesConceded = 3,
                            YellowCards = 3,
                            RedCards = 3,
                            PlayerId = 1,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 7,
                            Tries = 3,
                            TryAssists = 3,
                            Conversions = 3,
                            PenaltyGoals = 3,
                            DropGoals = 3,
                            MetersRun = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            CleanBreaks = 3,
                            LineoutsWon = 3,
                            LineoutsLost = 3,
                            Tackles = 53,
                            TacklesMissed = 3,
                            ScrumsWon = 3,
                            ScrumsLost = 3,
                            TotalScrums = 3,
                            TurnoversWon = 3,
                            PenaltiesConceded = 3,
                            YellowCards = 3,
                            RedCards = 3,
                            PlayerId = 1,
                            FixtureId = 7,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 8,
                            Tries = 3,
                            TryAssists = 3,
                            Conversions = 3,
                            PenaltyGoals = 3,
                            DropGoals = 3,
                            MetersRun = 3,
                            Carries = 3,
                            Passes = 3,
                            Offloads = 3,
                            CleanBreaks = 3,
                            LineoutsWon = 3,
                            LineoutsLost = 3,
                            Tackles = 53,
                            TacklesMissed = 3,
                            ScrumsWon = 3,
                            ScrumsLost = 3,
                            TotalScrums = 3,
                            TurnoversWon = 3,
                            PenaltiesConceded = 3,
                            YellowCards = 3,
                            RedCards = 3,
                            PlayerId = 1,
                            FixtureId = 8,
                        },
                        // Add more sample player match statistics as needed
                    };

                    context.PlayersStatistics.AddRange(playersStatistics);
                }
                context.SaveChanges();
            }
        }
    }
}