namespace RugbyDataApi.Models
{
    public class SECReferees
    {
        public string? id {get; set;} // E.g: "sr:referee:864634"
        public string? name {get; set;} // E.g: "Jones, Adam"
        public string? nationality {get; set;} // E.g: "Wales"
        public string? country_code {get; set;} // E.g: "WAL"
        public string? type {get; set;} // E.g: "main_referee"
    }
}