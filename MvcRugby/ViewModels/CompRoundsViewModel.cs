using MvcRugby.Models;

// View model for the SportsRadar CompRounds View
// Model 1: Display all rounds for a given competition. Data from: List<lineups> / sport_event / sport_event_context / round / number

namespace MvcRugby.ViewModels
{
    public class CompRoundsViewModel
    {
        public string? CompetitionName { get; set; } // One competition name, hence a single attribute is sufficient
        public string? SeasonId { get; set; } // One season Id, hence a single attribute is sufficient
        public List<RoundViewModel>? Rounds { get; set; } // multiple rounds in the comp, hence a list is required
    }

    public class RoundViewModel // for each round, the following details will be stored
    {
        public int RoundNumber { get; set; }
        public string? Status { get; set; }
        public DateTime StartTime { get; set; }
        public bool StartTimeConfirmed { get; set; }
    }
}