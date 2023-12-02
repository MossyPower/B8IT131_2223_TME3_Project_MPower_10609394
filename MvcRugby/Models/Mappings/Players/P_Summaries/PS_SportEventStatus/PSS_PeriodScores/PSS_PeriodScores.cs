// Naming Convention Meaning: 
// PSSS = Players | Summaries | Sport Event Status 

namespace MvcRugby.Mappings
{
    public class PSS_PeriodScores
    {
        public int? home_score { get; set; } // 6
        public int? away_score { get; set; } // 10
        public string? type { get; set; } // "regular_period"
        public int? number { get; set; } // 1
    }
}