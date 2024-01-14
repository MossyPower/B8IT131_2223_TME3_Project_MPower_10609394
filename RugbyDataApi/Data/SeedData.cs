// using Microsoft.EntityFrameworkCore;
// using RugbyDataApi.Models;

// namespace RugbyDataApi.Data
// {
//     public static class SeedData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//             using (var context = new RugbyDataDbContext(serviceProvider.GetRequiredService<DbContextOptions<RugbyDataDbContext>>()))
//             {

//                 // Look for any clubs.
//                 if (!context.Club.Any())
//                 {
//                     // Create sample clubs
//                     var clubs = new List<Club>
//                     {
//                         new Club
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:club:123",
//                             Competition_Name = "Sample Competition",
//                             Club_Name = "Sample Club 1",
//                             Country = "Sample Country"
//                         },
//                         // Add more sample clubs as needed
//                     };

//                     context.Club.AddRange(clubs);
//                 }

//                 // ************************************

//                 // Look for any competitions.
//                 if (!context.Competitions.Any())
//                 {
//                     // Create sample competitions
//                     var competitions = new List<Competition>
//                     {
//                         new Competition
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:competition:419",
//                             Competition_Name = "Sample Competition 1",
//                             Start_Date = new DateTime(2024, 1, 1),
//                             End_Date = new DateOnly(2024, 1, 10),
//                             Season = context.Seasons.FirstOrDefault(), // Assuming you want to associate with the first season
//                         },
//                         // Add more sample competitions as needed
//                     };

//                     context.Competitions.AddRange(competitions);
//                 }

//                 // ************************************

//                 // Look for any Competition Round.
//                 if (!context.CompetitionRounds.Any())
//                 {
//                     // Create sample competition rounds
//                     var competitionRounds = new List<CompetitionRound>
//                     {
//                         new CompetitionRound
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:round:567",
//                             Status = "Active",
//                             Start_Date = new DateOnly(2024, 1, 1),
//                             End_Date = new DateOnly(2024, 1, 5),
//                             Competition = context.Competitions.FirstOrDefault() // Assuming you want to associate with the first competition
//                         },
//                         // Add more sample competition rounds as needed
//                     };

//                     context.CompetitionRounds.AddRange(competitionRounds);
//                 }

//                 // ************************************

//                 // Look for any Competition Game.
//                 if (!context.CompetitionGames.Any())
//                 {
//                     // Create sample competition games
//                     var competitionGames = new List<CompetitionGame>
//                     {
//                         new CompetitionGame
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:game:789",
//                             Round_Number = 1,
//                             Status = "Scheduled",
//                             Start_Date = new DateTime(2024, 1, 2),
//                             End_Date = new DateTime(2024, 1, 2),
//                             CompetitionRound = context.CompetitionRounds.FirstOrDefault(), // Assuming you want to associate with the first competition round
//                             Competition = context.Competitions.FirstOrDefault() // Assuming you want to associate with the first competition
//                         },
//                         // Add more sample competition games as needed
//                     };

//                     context.CompetitionGames.AddRange(competitionGames);
//                 }

//                 // ************************************

//                 // Look for any Match Day Team.
//                 if (!context.MatchDayTeams.Any())
//                 {
//                     // Create sample match day teams
//                     var matchDayTeams = new List<MatchDayTeam>
//                     {
//                         new MatchDayTeam
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:matchdayteam:987",
//                             Clubs = context.Club.ToList(), // Assuming you want to associate with all clubs
//                             CompetitionGame = context.CompetitionGames.FirstOrDefault() // Assuming you want to associate with the first competition game
//                         },
//                         // Add more sample match day teams as needed
//                     };

//                     context.MatchDayTeams.AddRange(matchDayTeams);
//                 }

//                 // ************************************

//                 // Look for any Player.
//                 if (!context.Players.Any())
//                 {
//                     // Create sample players
//                     var players = new List<Player>
//                     {
//                         new Player
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:player:111",
//                             First_Name = "John",
//                             Last_Name = "Doe",
//                             Nationality = "Sample Nationality",
//                             Position = "Forward",
//                             Jersey_Number = "10",
//                             Age = "25",
//                             Weight = "85",
//                             Statistics = context.PlayersMatchStatistics.ToList(), // Assuming you want to associate with all player match statistics
//                             Club = context.Club.FirstOrDefault() // Assuming you want to associate with the first club
//                         },
//                         // Add more sample players as needed
//                     };

//                     context.Players.AddRange(players);
//                 }

//                 // ************************************

//                 // Look for any Player Match Statistics.
//                 if (!context.PlayersMatchStatistics.Any())
//                 {
//                     // Create sample player match statistics
//                     var playerMatchStatistics = new List<PlayerMatchStatistics>
//                     {
//                         new PlayerMatchStatistics
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:statistics:123",
//                             Tries = "5",
//                             Try_Assists = 2,
//                             Conversions = 1,
//                             Penalty_Goals = 0,
//                             Drop_Goals = 0,
//                             Ball_Possessition = 65,
//                             Meters_Run = 120,
//                             Carries = 15,
//                             Passes = 20,
//                             Offloads = 3,
//                             Clean_Breaks = 2,
//                             Lineouts_Won = 5,
//                             Lineouts_Lost = 1,
//                             Tackles = 10,
//                             Tackles_Missed = 2,
//                             Scrums_Won = 3,
//                             Scrums_Lost = 0,
//                             Total_Scrums = 3,
//                             Turnovers_Won = 1,
//                             Penalties_Conceded = 2,
//                             Yellow_Cards = 0,
//                             Red_Cards = 0,
//                             CompetitionGame = context.CompetitionGames.FirstOrDefault(), // Assuming you want to associate with the first competition game
//                             Player = context.Players.FirstOrDefault() // Assuming you want to associate with the first player
//                         },
//                         // Add more sample player match statistics as needed
//                     };

//                     context.PlayersMatchStatistics.AddRange(playerMatchStatistics);
//                 }
                
//                 // Look for any Season.
//                 if (!context.Seasons.Any())
//                 {
//                     // Create sample seasons
//                     var seasons = new List<Season>
//                     {
//                         new Season
//                         {
//                             Id = "1",
//                             SportRadar_Id = "sr:season:106497",
//                             Year = "23/24",
//                             Start_Date = new DateTime(2023, 10, 21),
//                             End_Date = new DateTime(2024, 5, 15),
//                             Competition_Name = "Sample Competition 1"
//                         },
//                         // Add more sample seasons as needed
//                     };

//                     context.Seasons.AddRange(seasons);
//                 }

//                 // ************************************
//                 context.SaveChanges();
//             }
//         }
//     }
// }