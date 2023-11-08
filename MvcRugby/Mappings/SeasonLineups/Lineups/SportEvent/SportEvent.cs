namespace MvcRugby.Mappings
{
    public class SportEvent
    {
        public string? id {get; set;} // E.g: "sr:sport_event:42404611"
        public string? start_time {get; set;} // E.g: "2023-10-21T12:00:00+00:00"
        public bool? start_time_confirmed {get; set;} // E.g: true
        public SEContext? sport_event_context {get; set;}
        public SECoverage? coverage {get; set;}
        public List<SECompetitors>? competitors {get; set;}
        public SEVenue? venue {get; set;}
        public SEConditions? sport_event_conditions {get; set;}
    }
}