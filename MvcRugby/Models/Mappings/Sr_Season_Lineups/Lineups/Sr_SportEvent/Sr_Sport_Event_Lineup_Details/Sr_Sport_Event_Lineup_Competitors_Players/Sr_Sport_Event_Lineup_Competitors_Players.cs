namespace MvcRugby.Mappings
{
    public class Sr_Sport_Event_Lineup_Competitors_Players
    {
        public string? Sr_Id {get; set;} // E.g: "sr:player:505706"
        public string? Sr_Name {get; set;} // E.g: "Bigi, Luca"
        public string? Sr_Type {get; set;} // E.g: "HO"
        public string? Sr_Date_Of_Birth {get; set;} // E.g: "1991-04-19"
        public string? Sr_Nationality {get; set;} // E.g: "Italy"
        public string? Sr_Country_Code {get; set;} // E.g: "ITA"
        public int? Sr_Height {get; set;} // E.g: 181
        public int? Sr_Weight {get; set;} // E.g: 100
        public int? Sr_Jersey_Number {get; set;} // E.g: 2
        public bool? Sr_Starter {get; set;} // E.g: true
        public bool? Sr_Played {get; set;} // E.g: true
    }
}