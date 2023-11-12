// View model for the SportsRadar RoundLineup View
namespace MvcRugby.Models
{   
    // Model 1: Pull info from Mappings / SeasonLineups
    public class RoundLineupViewModel
    {
        public string? CompetitionName { get; set; } // One competition name, hence a single attribute is sufficient
        public int RoundNumber { get; set; } // Single round per view, hence one attribute sufficient
        public List<RoundTeams>? Teams { get; set; } // multiple teams in a round, hence a list is required
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
    
    //Model 2: Pull info from Mappings / Players
    //public class PlayerViewModel
    //{
        // Properties specific to the player view
        // public string PlayerName { get; set; }
    //}
}