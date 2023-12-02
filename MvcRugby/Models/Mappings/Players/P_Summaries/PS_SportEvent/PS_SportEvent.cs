namespace MvcRugby.Mappings;
public class PS_SportEvent
{
    public string? id { get; set; } // "sr:sport_event:42404659"
    public DateTime? start_time { get; set; } // "2023-11-10T17:30:00+00:00",
    public bool? start_time_confirmed { get; set; } // true
    public PSS_SportEventContext? sport_event_context { get; set; }
    public PSS_Coverage? coverage{ get; set; }
    public List<PSS_Competitors>? competitors { get; set; }
    public PSS_Venue? venue { get; set; }
    public PSS_SportEventConditions? sport_event_conditions { get; set; }

}