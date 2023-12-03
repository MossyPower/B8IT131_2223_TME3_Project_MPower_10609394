// Naming Convention Meaning: 
// PSSS = Player | Summaries | Sport Event | Sport Event Conditions

namespace RugbyDataApi.Models
{
    public class PSSS_Referees
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? nationality { get; set; }
        public string? country_code { get; set; }
        public string? type { get; set; }
    }
}