namespace MvcRugby.Models
{
    public class RoundsViewModel
    {
        public string CompetitionName { get; set; } // One competition name, hence a single attribute is sufficient
        public int CompetitionId { get; set; } // One season Id, hence a single attribute is sufficient
        public List<RoundInfoViewModel>? Rounds { get; set; } // multiple rounds in the comp, hence a list is required
    }

    public class RoundInfoViewModel // for each round, the following details will be stored
    {
        public int RoundNumber { get; set; }
        public string? Status { get; set; }
        // public string? StartDate { get; set; }
        // public string? EndDate { get; set; }
    }
}