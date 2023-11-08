namespace MvcRugby.Mappings
{
    public class SportEventLineupCompetitors
    {
        public string? id {get; set;} // E.g: "sr:competitor:75331"
        public string? name {get; set;} // E.g: "Zebre"
        public int? abbreviation {get; set;} // E.g: "ZEB"
        public int? qualifier {get; set;} // E.g: "home"
        public string? gender {get; set;} // E.g: "male"
        public List<SportEventLineupCompetitorsPlayers>? players {get; set;}
    }
}