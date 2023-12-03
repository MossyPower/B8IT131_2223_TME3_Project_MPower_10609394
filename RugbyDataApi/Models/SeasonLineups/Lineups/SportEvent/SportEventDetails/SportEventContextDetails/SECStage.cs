namespace RugbyDataApi.Models
{
    public class SECStage
    {
        public int? order {get; set;} //E.g: 1
        public string? type {get; set;} //E.g: "league"
        public string? phase {get; set;} //E.g: "regular season"
        public string? start_date {get; set;} // E.g: "2023-10-21"
        public string? end_date  {get; set;} // E.g: "2024-06-01"
        public string? round {get; set;} // E.g: "23/24"

    }
}