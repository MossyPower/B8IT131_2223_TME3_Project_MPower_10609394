namespace MvcRugby.Mappings
{
    public class SESPeriodScores
    {
        public int? home_score {get; set;} // E.g: 26
        public int? away_score {get; set;} // E.g: 21
        public string? type {get; set;} // E.g: "regular_period"
        public int? number {get; set;} // E.g: 1
    }
}