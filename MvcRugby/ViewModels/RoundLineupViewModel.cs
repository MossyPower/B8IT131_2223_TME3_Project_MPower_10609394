using MvcRugby.Models;

// View model for the SportsRadar RoundLineup View
namespace MvcRugby.ViewModels
{   
    // Combined ViewModel for (i) SeasonLineup & (ii) Players
    public class RoundLineupViewModel
    {
        public IEnumerable<RoundDetail>? RoundDetails { get; set;} // change this from IEnum, as this is only one instance...
        public IEnumerable<Player>? Players { get; set;}
    }
    
    // Model 1: Pull info from Mappings / SeasonLineups
    public class RoundDetail
    {
        public string? SeasonId { get; set; } // SeasonID; required for 'go-back' button
        public string? CompetitionName { get; set; } // Comp name; Required for top of view
        public int RoundNumber { get; set; } // Round Nr.; Required for top of view
        public List<RoundTeams>? Teams { get; set; } // multiple teams in given round round required
    }
    
    public class RoundTeams
    {
        public string? TeamId { get; set; }
        public string? TeamName { get; set; }
        public List<MatchSquad>? Players { get; set; } // multiple players in team, hence a list is required
    }

    public class MatchSquad // multiple players in a team, hence a list is required
    {
        public string? PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int? PlayerNumber { get; set; }
        public string? PlayerPosition { get; set; }
    }
    
    // Model 2: Pull info from Mappings / Players    
    public class Players
    {
        public int? BallPossession { get; set; }
        public int? Carries { get; set; }
        public int? CleanBreaks { get; set; } 
        public int? Conversions { get; set; }
        public int? DropGoals { get; set; }
        public int? LineoutsWon { get; set; }
        public int? MetersRun { get; set; }
        public int? Offloads { get; set; }
        public int? Passes { get; set; }
        public int? PenaltiesConceded { get; set; }
        public int? PenaltyGoals { get; set; }
        public int? RedCards { get; set; }
        public int? ScrumsLost { get; set; }
        public int? ScrumsWon { get; set; }
        public int? TackleMissed { get; set; }
        public int? Tackles { get; set; }
        public int? TotalScrums { get; set; }
        public int? Tries { get; set; }
        public int? TryAssist { get; set; }
        public int? TurnoversWon { get; set; }
        public int? YellowCards { get; set; }
    }
}