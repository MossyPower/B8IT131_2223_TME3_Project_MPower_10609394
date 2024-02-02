using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class PlayerStatisticsViewModel
    {
        public int? CompetitionId { get; set;}
        public string? CompetitionName { get; set;}
        
        public int? FixtureId { get; set;}
        public DateTime? FixtureStartTime { get; set;}

        public int? PlayerId { get; set;}
        public string? PlayerFirstName { get; set;}
        public string? PlayerLastName { get; set;}
        public PlayerStatistics? PlayerStatistics { get; set;}
        public string? Placeholder { get; set;}
    }
}