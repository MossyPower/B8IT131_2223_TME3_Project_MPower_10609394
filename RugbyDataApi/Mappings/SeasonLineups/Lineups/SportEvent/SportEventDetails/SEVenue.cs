namespace RugbyDataApi.Mappings
{
    // match day venue: 
    public class SEVenue
    {
        public string? id {get; set;} // E.g: "sr:venue:10089"
        public string? name {get; set;} // E.g: "Stadio Sergio Lanfranchi"
        public string? city_name {get; set;} // E.g: "Parma"
        public string? country_name {get; set;} // E.g: "Italy"
        public string? map_coordinates {get; set;} // E.g: "44.825087,10.333006"
        public string? country_code {get; set;} //E.g: "ITA"
        public string? timezone {get; set;} // E.g: "Europe/Rome"
    }
}