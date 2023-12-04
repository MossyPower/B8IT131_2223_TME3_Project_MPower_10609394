namespace RugbyDataApi.Mappings
{
    // match day venue: 
    public class Sr_SE_Venue
    {
        public string? Sr_Id {get; set;} // E.g: "sr:venue:10089"
        public string? Sr_Name {get; set;} // E.g: "Stadio Sergio Lanfranchi"
        public string? Sr_City_Name {get; set;} // E.g: "Parma"
        public string? Sr_Country_Name {get; set;} // E.g: "Italy"
        public string? Sr_Map_Coordinates {get; set;} // E.g: "44.825087,10.333006"
        public string? Sr_Country_Code {get; set;} //E.g: "ITA"
        public string? Sr_Timezone {get; set;} // E.g: "Europe/Rome"
    }
}