// Naming Convention Meaning: 
// PSSS = Player | Summaries | Sport Event | Sport Event Conditions
namespace MvcRugby.Mappings
{
    public class PSSS_Season
    {
        public string? id { get; set; } // "sr:season:106497"
        public string? name { get; set; } // "United Rugby Championship 23/24"
        public DateOnly? start_date { get; set; } // "2023-10-21"
        public DateOnly? end_date { get; set; } // "2024-06-22"
        public string? year { get; set; } // "23/24"
        public string? competition_id { get; set; } // "sr:competition:419"
    }
}