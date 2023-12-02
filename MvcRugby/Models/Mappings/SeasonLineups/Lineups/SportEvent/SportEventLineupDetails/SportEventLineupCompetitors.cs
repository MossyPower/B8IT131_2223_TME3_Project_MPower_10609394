namespace MvcRugby.Mappings
{
    public class SportEventLineupCompetitors
    {
        public string? id {get; set;} // E.g: "sr:competitor:75331"
        public string? name {get; set;} // E.g: "Zebre"
        public string? abbreviation {get; set;} // E.g: "ZEB"
        public string? qualifier {get; set;} // E.g: "home"
        public string? gender {get; set;} // E.g: "male"
        public List<SportEventLineupCompetitorsPlayers>? players {get; set;}
    }
}