// Naming Convention Meaning: 
// PSSV = Player | Summaries | Sport Event | Venue
namespace RugbyDataApi.Models
{
    public class PSS_Venue
    {
        public string? id { get; set; } // "sr:venue:10089"
        public string? name { get; set; } // "Stadio Sergio Lanfranchi"
        public string? city_name { get; set; } // "Parma"
        public string? country_name { get; set; } // "Italy"
        public string? map_coordinates { get; set; } // "44.825087,10.333006"
        public string? country_code { get; set; } // "ITA"
        public string? timezone { get; set; } // "Europe/Rome"
    }
}