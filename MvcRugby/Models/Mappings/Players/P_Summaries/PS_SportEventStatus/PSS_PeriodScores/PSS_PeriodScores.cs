// Naming Convention Meaning: 
// PSSS = Players | Summaries | Sport Event Status 

namespace MvcRugby.Mappings;
public class PSS_PeriodScores
{
    public string? home_score { get; set; } // 6
    public string? away_score { get; set; } // 10
    public int? type { get; set; } // "regular_period"
    public int? number { get; set; } // 1
}