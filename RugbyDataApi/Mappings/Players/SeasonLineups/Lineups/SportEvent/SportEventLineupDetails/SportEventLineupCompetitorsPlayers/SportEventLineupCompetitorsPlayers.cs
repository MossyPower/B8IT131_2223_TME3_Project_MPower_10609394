namespace RugbyDataApi.Mappings
{
    public class SportEventLineupCompetitorsPlayers
    {
        public string? id {get; set;} // E.g: "sr:player:505706"
        public string? name {get; set;} // E.g: "Bigi, Luca"
        public string? type {get; set;} // E.g: "HO"
        public string? date_of_birth {get; set;} // E.g: "1991-04-19"
        public string? nationality {get; set;} // E.g: "Italy"
        public string? country_code {get; set;} // E.g: "ITA"
        public int? height {get; set;} // E.g: 181
        public int? weight {get; set;} // E.g: 100
        public int? jersey_number {get; set;} // E.g: 2
        public bool? starter {get; set;} // E.g: true
        public bool? played {get; set;} // E.g: true
    }
}