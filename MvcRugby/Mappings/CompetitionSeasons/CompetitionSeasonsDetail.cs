namespace MvcRugby.Mappings
{
    public class CompetitionSeasonsDetails
    {
        public string? id { get; set; } // E.g: "sr:season:1296"
        public string? name { get; set; } // E.g: "Magners League 07/08"
        public string? start_date { get; set; } // E.g: "2007-08-30"
        public string? end_date { get; set; } // E.g: "2008-05-13"
        public string? year { get; set; } // E.g: "07/08"
        public string? competition_id { get; set; } // E.g: "sr:competition:419"
    }
}