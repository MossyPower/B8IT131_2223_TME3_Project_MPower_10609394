namespace MvcRugby.Mappings
{
    public class SportEventStatus
    {
        public string? status {get; set;} // E.g: "closed"
        public string? match_status {get; set;} // E.g: "ended"
        public int? home_score {get; set;} // E.g: 36
        public int? away_score {get; set;} // E.g: 40
        public string? winner_id {get; set;} // E.g: "sr:competitor:4211"
        public SESPeriodScores? period_scores {get; set;}
    }
}