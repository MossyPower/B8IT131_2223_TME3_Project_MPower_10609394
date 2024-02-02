using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class ComparisonViewModel
    {
        [Required]
        
        public List<Fixture>? Fixtures { get; set; }
        public List<TeamLineup>? TeamLineups { get; set; }
        public List<List<PlayerLineup>>? PlayerLineups { get; set; }
        public List<PlayerStatistics>? PlayersStatistics { get; set;}

        public List<Team>? Teams { get; set; }
        public List<List<Player>>? Players { get; set; }
        
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public List<RoundTeam>? RoundTeams { get; set; } //set out below
    }

    public class RoundTeam
    {
        public int? TeamId { get; set; }
        public string? TeamName { get; set; }

        public List<RoundPlayer> RoundPlayers { get; set; }

        public List<PlayerRoundStats> PlayersStats { get; set; }
    }

    public class RoundPlayer
    {
        public int? PlayerId { get; set; }
        public string? PlayerFirstName { get; set; }
        public string? PlayerLastName { get; set; }
    }

    public class PlayerRoundStats
    {
        public int PlayerStatisticsId { get; set; }
        public int? Tries { get; set; }
        public int? TryAssists { get; set; } 
        public int? Conversions { get; set; } 
        public int? PenaltyGoals { get; set; } 
        public int? DropGoals { get; set; } 
        public int? MetersRun { get; set; } 
        public int? Carries { get; set; } 
        public int? Passes { get; set; }
        public int? Offloads { get; set; } 
        public int? CleanBreaks { get; set; } 
        public int? LineoutsWon { get; set; } 
        public int? LineoutsLost { get; set; }     
        public int? Tackles { get; set; } 
        public int? TacklesMissed { get; set; } 
        public int? ScrumsWon { get; set; } 
        public int? ScrumsLost { get; set; } 
        public int? TotalScrums { get; set; } 
        public int? TurnoversWon { get; set; } 
        public int? PenaltiesConceded { get; set; } 
        public int? YellowCards { get; set; } 
        public int? RedCards { get; set; } 
    }
}