namespace MvcRugby.Mappings
{
    public class SECSeason
    {
        public string? id {get; set;} // E.g: "sr:season:106497"
        public string? name {get; set;} // E.g: "United Rugby Championship 23/24"
        public string? start_date {get; set;} // E.g: "2023-10-21"
        public string? end_date  {get; set;} // E.g: "2024-06-22"
        public string? year {get; set;} // E.g: "23/24"
        public string? competition_id {get; set;} // E.g: "sr:competition:419"
    }
}