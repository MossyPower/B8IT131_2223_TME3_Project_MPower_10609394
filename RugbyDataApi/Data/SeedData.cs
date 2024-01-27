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

                // Look for any teams.
                if (!context.Teams.Any())
                {
                    // Create sample teams (use URC as example)
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
                
                // Look for any Player.
                if (!context.Players.Any())
                {
                    // Create sample players
                    var players = new List<Player>
                    {
                        new Player // Obtain from Sport Radar Api > Season Players Endpoint
                        {
                            PlayerId = 1,
                            SrPlayerId = "sr:player:470190",
                            FirstName = "Stephen Desmond",
                            LastName = "Archer",
                            DateOfBirth = new DateOnly(1988,1,29),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 2,
                            SrPlayerId = "sr:player:1143380",
                            FirstName = "Diarmuid",
                            LastName = "Barron",
                            DateOfBirth = new DateOnly(1988,8,6),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 3,
                            SrPlayerId = "sr:player:798952",
                            FirstName = "Joey",
                            LastName = "Carbery",
                            DateOfBirth = new DateOnly(1995,11,1),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 4,
                            SrPlayerId = "sr:player:492958",
                            FirstName = "Andrew",
                            LastName = "Conway",
                            DateOfBirth = new DateOnly(1991,7,11),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 5,
                            SrPlayerId = "sr:player:1069614",
                            FirstName = "Gavin",
                            LastName = "Coombes",
                            DateOfBirth = new DateOnly(1997,12,11),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 6,
                            SrPlayerId = "sr:player:2141720",
                            FirstName = "Ethan",
                            LastName = "Coughlan",
                            DateOfBirth = null,
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 7,
                            SrPlayerId = "sr:player:952230",
                            FirstName = "Shane",
                            LastName = "Daly",
                            DateOfBirth = new DateOnly(1996,12,19),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 8,
                            SrPlayerId = "sr:player:2456151",
                            FirstName = "Edwin",
                            LastName = "Edogbo",
                            DateOfBirth = null,
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 9,
                            SrPlayerId = "sr:player:2186246",
                            FirstName = "Antoine",
                            LastName = "Frisch",
                            DateOfBirth = new DateOnly(1996,6,1),
                            Nationality = "France",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 10,
                            SrPlayerId = "sr:player:2135950",
                            FirstName = "Alex",
                            LastName = "Kendellen",
                            DateOfBirth = null,
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 11,
                            SrPlayerId = "sr:player:515336",
                            FirstName = "Jack",
                            LastName = "O'Donoghue",
                            DateOfBirth = new DateOnly(194,2,8),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 12,
                            SrPlayerId = "sr:player:516848",
                            FirstName = "Rory",
                            LastName = "Scannell",
                            DateOfBirth = new DateOnly(1993,12,22),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 13,
                            SrPlayerId = "sr:player:1693331",
                            FirstName = "Josh",
                            LastName = "Wycherley",
                            DateOfBirth = new DateOnly(1997,7,22),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 14,
                            SrPlayerId = "sr:player:1069622",
                            FirstName = "Fineen",
                            LastName = "Wycherley",
                            DateOfBirth = new DateOnly(1997,12,11),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 15,
                            SrPlayerId = "sr:player:2090895",
                            FirstName = "Thomas",
                            LastName = "Ahern",
                            DateOfBirth = new DateOnly(2000,2,22),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 16,
                            SrPlayerId = "sr:player:2276501",
                            FirstName = "Scott",
                            LastName = "Buckley",
                            DateOfBirth = new DateOnly(2000,6,13),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 17,
                            SrPlayerId = "sr:player:770139",
                            FirstName = "Neil",
                            LastName = "Cronin",
                            DateOfBirth = new DateOnly(1992,12,6),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 18,
                            SrPlayerId = "sr:player:2708666",
                            FirstName = "Brian",
                            LastName = "Gleeson",
                            DateOfBirth = new DateOnly(2004,2,5),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 19,
                            SrPlayerId = "sr:player:2708668",
                            FirstName = "Shay",
                            LastName = "McCarthy",
                            DateOfBirth = null,
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 20,
                            SrPlayerId = "sr:player:878686",
                            FirstName = "Alex",
                            LastName = "Nankivell",
                            DateOfBirth = new DateOnly(1996,11,25),
                            Nationality = "New Zealand",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 21,
                            SrPlayerId = "sr:player:504510",
                            FirstName = "John",
                            LastName = "Ryan",
                            DateOfBirth = new DateOnly(1988,8,2),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 22,
                            SrPlayerId = "sr:player:2708664",
                            FirstName = "Kieran",
                            LastName = "Ryan",
                            DateOfBirth = new DateOnly(2002,1,30),
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                        new Player
                        {
                            PlayerId = 23,
                            SrPlayerId = "sr:player:2464931",
                            FirstName = "Fionn",
                            LastName = "Gibbons",
                            DateOfBirth = null,
                            Nationality = "Ireland",
                            TeamId = 1,
                        },
                    };

                    context.Players.AddRange(players);
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
                            HomeScore = 34,
                            AwayScore = 26,
                            CompetitionId = 2,
                        },
                        new Fixture
                        {
                            FixtureId = 3,
                            SrSportEventId = "sr:sport_event:42404615",
                            RoundNumber = 1,
                            StartTime = new DateTime(2023,10,21,14,05,00,00,00),
                            Status = "closed",
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
                            TeamLineupId = 2,
                            Designation = "Away",
                            FixtureId = 1,
                            TeamId = 4,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 3,
                            Designation = "Home",
                            FixtureId = 2,
                            TeamId = 3,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 4,
                            Designation = "Away",
                            FixtureId = 2,
                            TeamId = 12,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 5,
                            Designation = "Home",
                            FixtureId = 3,
                            TeamId = 5,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 6,
                            Designation = "Away",
                            FixtureId = 3,
                            TeamId = 7,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 7,
                            Designation = "Home",
                            FixtureId = 4,
                            TeamId = 13,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 8,
                            Designation = "Away",
                            FixtureId = 4,
                            TeamId = 9,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 9,
                            Designation = "Home",
                            FixtureId = 5,
                            TeamId = 11,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 10,
                            Designation = "Away",
                            FixtureId = 5,
                            TeamId = 14,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 11,
                            Designation = "Home",
                            FixtureId = 6,
                            TeamId = 1,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 12,
                            Designation = "Away",
                            FixtureId = 6,
                            TeamId = 6,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 13,
                            Designation = "Home",
                            FixtureId = 7,
                            TeamId = 16,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 14,
                            Designation = "Away",
                            FixtureId = 7,
                            TeamId = 8,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 15,
                            Designation = "Home",
                            FixtureId = 8,
                            TeamId = 10,
                        },
                        new TeamLineup
                        {
                            TeamLineupId = 16,
                            Designation = "Away",
                            FixtureId = 8,
                            TeamId = 2,
                        },
                        // Add more sample players as needed
                    };
                    context.TeamLineups.AddRange(teamLineups);
                }
                context.SaveChanges();
                // ************************************

                // Look for any Player Lineup.
                if (!context.PlayerLineups.Any())
                {
                    // Create sample players
                    var playerLineups = new List<PlayerLineup>
                    {
                        new PlayerLineup
                        {
                            PlayerLineupId = 1,
                            TeamLineupId = 11,
                            PlayerId = 13,
                            SrPlayerId = "sr:player:470190",
                            JerseyNumber = 1,
                        },

                        new PlayerLineup
                        {
                            PlayerLineupId = 2,
                            TeamLineupId = 11,
                            PlayerId = 2,
                            SrPlayerId = "sr:player:1143380",
                            JerseyNumber = 2,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 3,
                            TeamLineupId = 11,
                            PlayerId = 1,
                            SrPlayerId = "sr:player:798952",
                            JerseyNumber = 3,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 4,
                            TeamLineupId = 11,
                            PlayerId = 8,
                            SrPlayerId = "sr:player:492958",
                            JerseyNumber = 4,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 5,
                            TeamLineupId = 11,
                            PlayerId = 14,
                            SrPlayerId = "sr:player:1069614",
                            JerseyNumber = 5,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 6,
                            TeamLineupId = 11,
                            PlayerId = 11,
                            SrPlayerId = "sr:player:2141720",
                            JerseyNumber = 6,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 7,
                            TeamLineupId = 11,
                            PlayerId = 10,
                            SrPlayerId = "sr:player:952230",
                            JerseyNumber = 7,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 8,
                            TeamLineupId = 11,
                            PlayerId = 5,
                            SrPlayerId = "sr:player:2456151",
                            JerseyNumber = 8,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 9,
                            TeamLineupId = 11,
                            PlayerId = 6,
                            SrPlayerId = "sr:player:2186246",
                            JerseyNumber = 9,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 10,
                            TeamLineupId = 11,
                            PlayerId = 3,
                            SrPlayerId = "sr:player:2135950",
                            JerseyNumber = 10,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 11,
                            TeamLineupId = 11,
                            PlayerId = 19,
                            SrPlayerId = "sr:player:515336",
                            JerseyNumber = 11,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 12,
                            TeamLineupId = 11,
                            PlayerId = 12,
                            SrPlayerId = "sr:player:516848",
                            JerseyNumber = 12,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 13,
                            TeamLineupId = 11,
                            PlayerId = 9,
                            SrPlayerId = "sr:player:1693331",
                            JerseyNumber = 13,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 14,
                            TeamLineupId = 11,
                            PlayerId = 4,
                            SrPlayerId = "sr:player:1069622",
                            JerseyNumber = 14,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 15,
                            TeamLineupId = 11,
                            PlayerId = 7,
                            SrPlayerId = "sr:player:2090895",
                            JerseyNumber = 15,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 16,
                            TeamLineupId = 11,
                            PlayerId = 16,
                            SrPlayerId = "sr:player:2276501",
                            JerseyNumber = 16,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 17,
                            TeamLineupId = 11,
                            PlayerId = 22,
                            SrPlayerId = "sr:player:770139",
                            JerseyNumber = 17,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 18,
                            TeamLineupId = 11,
                            PlayerId = 21,
                            SrPlayerId = "sr:player:2708666",
                            JerseyNumber = 18,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 19,
                            TeamLineupId = 11,
                            PlayerId = 15,
                            SrPlayerId = "sr:player:2708668",
                            JerseyNumber = 19,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 20,
                            TeamLineupId = 11,
                            PlayerId = 18,
                            SrPlayerId = "sr:player:878686",
                            JerseyNumber = 20,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 21,
                            TeamLineupId = 11,
                            PlayerId = 17,
                            SrPlayerId = "sr:player:504510",
                            JerseyNumber = 21,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 22,
                            TeamLineupId = 11,
                            PlayerId = 20,
                            SrPlayerId = "sr:player:2708664",
                            JerseyNumber = 22,
                        },
                        new PlayerLineup
                        {
                            PlayerLineupId = 23,
                            TeamLineupId = 11,
                            PlayerId = 23,
                            SrPlayerId = "sr:player:2464931",
                            JerseyNumber = 23,
                        },
                    };
                    context.PlayerLineups.AddRange(playerLineups);
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
                            FixtureId = 6,
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
                            PlayerId = 2,
                            FixtureId = 6,
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
                            PlayerId = 3,
                            FixtureId = 6,
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
                            PlayerId = 4,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 5,
                            Tries = 5,
                            TryAssists = 5,
                            Conversions = 5,
                            PenaltyGoals = 5,
                            DropGoals = 5,
                            MetersRun = 5,
                            Carries = 5,
                            Passes = 5,
                            Offloads = 5,
                            CleanBreaks = 5,
                            LineoutsWon = 5,
                            LineoutsLost = 5,
                            Tackles = 5,
                            TacklesMissed = 5,
                            ScrumsWon = 5,
                            ScrumsLost = 5,
                            TotalScrums = 5,
                            TurnoversWon = 5,
                            PenaltiesConceded = 5,
                            YellowCards = 5,
                            RedCards = 5,
                            PlayerId = 5,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 6,
                            Tries = 6,
                            TryAssists = 6,
                            Conversions = 6,
                            PenaltyGoals = 6,
                            DropGoals = 6,
                            MetersRun = 6,
                            Carries = 6,
                            Passes = 6,
                            Offloads = 6,
                            CleanBreaks = 6,
                            LineoutsWon = 6,
                            LineoutsLost = 6,
                            Tackles = 6,
                            TacklesMissed = 6,
                            ScrumsWon = 6,
                            ScrumsLost = 6,
                            TotalScrums = 6,
                            TurnoversWon = 6,
                            PenaltiesConceded = 6,
                            YellowCards = 6,
                            RedCards = 6,
                            PlayerId = 6,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 7,
                            Tries = 7,
                            TryAssists = 7,
                            Conversions = 7,
                            PenaltyGoals = 7,
                            DropGoals = 7,
                            MetersRun = 7,
                            Carries = 7,
                            Passes = 7,
                            Offloads = 7,
                            CleanBreaks = 7,
                            LineoutsWon = 7,
                            LineoutsLost = 7,
                            Tackles = 7,
                            TacklesMissed = 7,
                            ScrumsWon = 7,
                            ScrumsLost = 7,
                            TotalScrums = 7,
                            TurnoversWon = 7,
                            PenaltiesConceded = 7,
                            YellowCards = 0,
                            RedCards = 0,
                            PlayerId = 7,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 8,
                            Tries = 8,
                            TryAssists = 8,
                            Conversions = 8,
                            PenaltyGoals = 8,
                            DropGoals = 8,
                            MetersRun = 8,
                            Carries = 8,
                            Passes = 8,
                            Offloads = 8,
                            CleanBreaks = 8,
                            LineoutsWon = 8,
                            LineoutsLost = 8,
                            Tackles = 8,
                            TacklesMissed = 8,
                            ScrumsWon = 8,
                            ScrumsLost = 8,
                            TotalScrums = 8,
                            TurnoversWon = 8,
                            PenaltiesConceded = 8,
                            YellowCards = 8,
                            RedCards = 8,
                            PlayerId = 8,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 9,
                            Tries = 9,
                            TryAssists = 9,
                            Conversions = 9,
                            PenaltyGoals = 9,
                            DropGoals = 9,
                            MetersRun = 9,
                            Carries = 9,
                            Passes = 9,
                            Offloads = 9,
                            CleanBreaks = 9,
                            LineoutsWon = 9,
                            LineoutsLost = 9,
                            Tackles = 9,
                            TacklesMissed = 9,
                            ScrumsWon = 9,
                            ScrumsLost = 9,
                            TotalScrums = 9,
                            TurnoversWon = 9,
                            PenaltiesConceded = 9,
                            YellowCards = 9,
                            RedCards = 9,
                            PlayerId = 9,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 10,
                            Tries = 10,
                            TryAssists = 10,
                            Conversions = 10,
                            PenaltyGoals = 10,
                            DropGoals = 10,
                            MetersRun = 10,
                            Carries = 10,
                            Passes = 10,
                            Offloads = 10,
                            CleanBreaks = 10,
                            LineoutsWon = 10,
                            LineoutsLost = 10,
                            Tackles = 10,
                            TacklesMissed = 10,
                            ScrumsWon = 10,
                            ScrumsLost = 10,
                            TotalScrums = 10,
                            TurnoversWon = 10,
                            PenaltiesConceded = 10,
                            YellowCards = 10,
                            RedCards = 10,
                            PlayerId = 10,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 11,
                            Tries = 11,
                            TryAssists = 11,
                            Conversions = 11,
                            PenaltyGoals = 11,
                            DropGoals = 11,
                            MetersRun = 11,
                            Carries = 11,
                            Passes = 11,
                            Offloads = 11,
                            CleanBreaks = 11,
                            LineoutsWon = 11,
                            LineoutsLost = 11,
                            Tackles = 11,
                            TacklesMissed = 11,
                            ScrumsWon = 11,
                            ScrumsLost = 11,
                            TotalScrums = 11,
                            TurnoversWon = 11,
                            PenaltiesConceded = 11,
                            YellowCards = 11,
                            RedCards = 11,
                            PlayerId = 11,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 12,
                            Tries = 12,
                            TryAssists = 12,
                            Conversions = 12,
                            PenaltyGoals = 12,
                            DropGoals = 12,
                            MetersRun = 12,
                            Carries = 12,
                            Passes = 12,
                            Offloads = 12,
                            CleanBreaks = 12,
                            LineoutsWon = 12,
                            LineoutsLost = 12,
                            Tackles = 12,
                            TacklesMissed = 12,
                            ScrumsWon = 12,
                            ScrumsLost = 12,
                            TotalScrums = 12,
                            TurnoversWon = 12,
                            PenaltiesConceded = 12,
                            YellowCards = 12,
                            RedCards = 12,
                            PlayerId = 12,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 13,
                            Tries = 13,
                            TryAssists = 13,
                            Conversions = 13,
                            PenaltyGoals = 13,
                            DropGoals = 13,
                            MetersRun = 13,
                            Carries = 13,
                            Passes = 13,
                            Offloads = 13,
                            CleanBreaks = 13,
                            LineoutsWon = 13,
                            LineoutsLost = 13,
                            Tackles = 13,
                            TacklesMissed = 13,
                            ScrumsWon = 13,
                            ScrumsLost = 13,
                            TotalScrums = 13,
                            TurnoversWon = 13,
                            PenaltiesConceded = 13,
                            YellowCards = 13,
                            RedCards = 13,
                            PlayerId = 13,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 14,
                            Tries = 14,
                            TryAssists = 14,
                            Conversions = 14,
                            PenaltyGoals = 14,
                            DropGoals = 14,
                            MetersRun = 14,
                            Carries = 14,
                            Passes = 14,
                            Offloads = 14,
                            CleanBreaks = 14,
                            LineoutsWon = 14,
                            LineoutsLost = 14,
                            Tackles = 14,
                            TacklesMissed = 14,
                            ScrumsWon = 14,
                            ScrumsLost = 14,
                            TotalScrums = 14,
                            TurnoversWon = 14,
                            PenaltiesConceded = 14,
                            YellowCards = 14,
                            RedCards = 14,
                            PlayerId = 14,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 15,
                            Tries = 15,
                            TryAssists = 15,
                            Conversions = 15,
                            PenaltyGoals = 15,
                            DropGoals = 15,
                            MetersRun = 15,
                            Carries = 15,
                            Passes = 15,
                            Offloads = 15,
                            CleanBreaks = 15,
                            LineoutsWon = 15,
                            LineoutsLost = 15,
                            Tackles = 15,
                            TacklesMissed = 15,
                            ScrumsWon = 15,
                            ScrumsLost = 15,
                            TotalScrums = 15,
                            TurnoversWon = 15,
                            PenaltiesConceded = 15,
                            YellowCards = 15,
                            RedCards = 15,
                            PlayerId = 15,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 16,
                            Tries = 16,
                            TryAssists = 16,
                            Conversions = 16,
                            PenaltyGoals = 16,
                            DropGoals = 16,
                            MetersRun = 16,
                            Carries = 16,
                            Passes = 16,
                            Offloads = 16,
                            CleanBreaks = 16,
                            LineoutsWon = 16,
                            LineoutsLost = 16,
                            Tackles = 16,
                            TacklesMissed = 16,
                            ScrumsWon = 16,
                            ScrumsLost = 16,
                            TotalScrums = 16,
                            TurnoversWon = 16,
                            PenaltiesConceded = 16,
                            YellowCards = 16,
                            RedCards = 16,
                            PlayerId = 16,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 17,
                            Tries = 17,
                            TryAssists = 17,
                            Conversions = 17,
                            PenaltyGoals = 17,
                            DropGoals = 17,
                            MetersRun = 17,
                            Carries = 17,
                            Passes = 17,
                            Offloads = 17,
                            CleanBreaks = 17,
                            LineoutsWon = 17,
                            LineoutsLost = 17,
                            Tackles = 17,
                            TacklesMissed = 17,
                            ScrumsWon = 17,
                            ScrumsLost = 17,
                            TotalScrums = 17,
                            TurnoversWon = 17,
                            PenaltiesConceded = 17,
                            YellowCards = 17,
                            RedCards = 17,
                            PlayerId = 17,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 18,
                            Tries = 18,
                            TryAssists = 18,
                            Conversions = 18,
                            PenaltyGoals = 18,
                            DropGoals = 18,
                            MetersRun = 18,
                            Carries = 18,
                            Passes = 18,
                            Offloads = 18,
                            CleanBreaks = 18,
                            LineoutsWon = 18,
                            LineoutsLost = 18,
                            Tackles = 18,
                            TacklesMissed = 18,
                            ScrumsWon = 18,
                            ScrumsLost = 18,
                            TotalScrums = 18,
                            TurnoversWon = 18,
                            PenaltiesConceded = 18,
                            YellowCards = 18,
                            RedCards = 18,
                            PlayerId = 18,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 19,
                            Tries = 19,
                            TryAssists = 19,
                            Conversions = 19,
                            PenaltyGoals = 19,
                            DropGoals = 19,
                            MetersRun = 19,
                            Carries = 19,
                            Passes = 19,
                            Offloads = 19,
                            CleanBreaks = 19,
                            LineoutsWon = 19,
                            LineoutsLost = 19,
                            Tackles = 19,
                            TacklesMissed = 19,
                            ScrumsWon = 19,
                            ScrumsLost = 19,
                            TotalScrums = 19,
                            TurnoversWon = 19,
                            PenaltiesConceded = 19,
                            YellowCards = 19,
                            RedCards = 19,
                            PlayerId = 19,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 20,
                            Tries = 20,
                            TryAssists = 20,
                            Conversions = 20,
                            PenaltyGoals = 20,
                            DropGoals = 20,
                            MetersRun = 20,
                            Carries = 20,
                            Passes = 20,
                            Offloads = 20,
                            CleanBreaks = 20,
                            LineoutsWon = 20,
                            LineoutsLost = 20,
                            Tackles = 20,
                            TacklesMissed = 20,
                            ScrumsWon = 20,
                            ScrumsLost = 20,
                            TotalScrums = 20,
                            TurnoversWon = 20,
                            PenaltiesConceded = 20,
                            YellowCards = 20,
                            RedCards = 20,
                            PlayerId = 20,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 21,
                            Tries = 21,
                            TryAssists = 21,
                            Conversions = 21,
                            PenaltyGoals = 21,
                            DropGoals = 21,
                            MetersRun = 21,
                            Carries = 21,
                            Passes = 21,
                            Offloads = 21,
                            CleanBreaks = 21,
                            LineoutsWon = 21,
                            LineoutsLost = 21,
                            Tackles = 21,
                            TacklesMissed = 21,
                            ScrumsWon = 21,
                            ScrumsLost = 21,
                            TotalScrums = 21,
                            TurnoversWon = 21,
                            PenaltiesConceded = 21,
                            YellowCards = 21,
                            RedCards = 21,
                            PlayerId = 21,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 22,
                            Tries = 22,
                            TryAssists = 22,
                            Conversions = 22,
                            PenaltyGoals = 22,
                            DropGoals = 22,
                            MetersRun = 22,
                            Carries = 22,
                            Passes = 22,
                            Offloads = 22,
                            CleanBreaks = 22,
                            LineoutsWon = 22,
                            LineoutsLost = 22,
                            Tackles = 22,
                            TacklesMissed = 22,
                            ScrumsWon = 22,
                            ScrumsLost = 22,
                            TotalScrums = 22,
                            TurnoversWon = 22,
                            PenaltiesConceded = 22,
                            YellowCards = 22,
                            RedCards = 22,
                            PlayerId = 22,
                            FixtureId = 6,
                        },
                        new PlayerStatistics
                        {
                            PlayerStatisticsId = 23,
                            Tries = 23,
                            TryAssists = 23,
                            Conversions = 23,
                            PenaltyGoals = 23,
                            DropGoals = 23,
                            MetersRun = 23,
                            Carries = 23,
                            Passes = 23,
                            Offloads = 23,
                            CleanBreaks = 23,
                            LineoutsWon = 23,
                            LineoutsLost = 23,
                            Tackles = 23,
                            TacklesMissed = 23,
                            ScrumsWon = 23,
                            ScrumsLost = 23,
                            TotalScrums = 23,
                            TurnoversWon = 23,
                            PenaltiesConceded = 23,
                            YellowCards = 23,
                            RedCards = 23,
                            PlayerId = 23,
                            FixtureId = 6,
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