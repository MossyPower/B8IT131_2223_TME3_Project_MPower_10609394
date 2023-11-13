// Naming Convention Meaning: 
// PSSS = Players | Summaries | Sport Event Status 

namespace MvcRugby.Mappings;
public class PS_SportEventStatus
{
    public string? status { get; set; } // "closed"
    public string? match_status { get; set; } // "ended"
    public int? home_score { get; set; } // 12
    public int? away_score { get; set; } // 10
    public string? winner_id { get; set; } // "sr:competitor:75331"
    public List<PSS_PeriodScores>? period_scores { get; set; }
}