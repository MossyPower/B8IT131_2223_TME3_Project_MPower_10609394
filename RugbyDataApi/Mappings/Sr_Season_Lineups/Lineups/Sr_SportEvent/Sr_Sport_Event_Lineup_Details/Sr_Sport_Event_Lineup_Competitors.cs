namespace RugbyDataApi.Mappings
{
    public class Sr_Sport_Event_Lineup_Competitors
    {
        public string? Sr_Id {get; set;} // E.g: "sr:competitor:75331"
        public string? Sr_name {get; set;} // E.g: "Zebre"
        public string? Sr_abbreviation {get; set;} // E.g: "ZEB"
        public string? Sr_qualifier {get; set;} // E.g: "home"
        public string? Sr_gender {get; set;} // E.g: "male"
        public List<Sr_Sport_Event_Lineup_Competitors_Players>? Sr_Players {get; set;}
    }
}