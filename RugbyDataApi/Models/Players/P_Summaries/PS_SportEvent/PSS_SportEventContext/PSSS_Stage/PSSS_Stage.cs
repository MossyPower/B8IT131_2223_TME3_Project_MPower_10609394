// Naming Convention Meaning: 
// PSSS = Player | Summaries | Sport Event | Sport Event Conditions
namespace RugbyDataApi.Models
{
    public class PSSS_Stage
    {
        public int ? order { get; set; } // 1
        public string ? type { get; set; } // "league"
        public string ? phase { get; set; } // "regular season"
        public DateOnly ? start_date { get; set; } // "2023-10-21"
        public DateOnly ? end_date { get; set; } // "2024-06-01"
        public string ? year { get; set; } // "23/24"
    }
}