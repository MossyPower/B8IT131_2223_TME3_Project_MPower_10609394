namespace RugbyDataApi.Mappings
{
    // Competing Team (e.g.: 75331, Zebre, ZEB, home, male)
    public class Sr_SE_Competitors
    {
        public string? Sr_Id {get; set;} // E.g: "sr:competitor:75331"
        public string? Sr_Name {get; set;} // E.g: "Zebre"
        public string? Sr_Abbreviation {get; set;} // E.g: "ZEB"
        public string? Sr_Qualifier {get; set;} // E.g: "home"
        public string? Sr_Gender {get; set;} // E.g: "male"
    }
}