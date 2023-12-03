namespace RugbyDataApi.Models
{
    public class PSST_Competitors
    {
        public string? id { get; set; } // Team Id
        public string? name { get; set; } // Team name
        public string? abbreviation { get; set; } // Team abbreviated name
        public string? qualifier { get; set; } // Home | Away
        public PSSTC_Statistics? Statistics { get; set; }
    }
}