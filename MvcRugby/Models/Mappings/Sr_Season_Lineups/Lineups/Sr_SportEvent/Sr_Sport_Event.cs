namespace MvcRugby.Mappings
{
    public class Sr_Sport_Event
    {
        public string? Sr_Id {get; set;} // E.g: "sr:sport_event:42404611"
        public string? Sr_start_Time {get; set;} // E.g: "2023-10-21T12:00:00+00:00"
        public bool? Sr_Start_Time_Confirmed {get; set;} // E.g: true
        public Sr_SE_Context? Sr_Sport_Event_Context {get; set;}
        public Sr_SE_Coverage? Sr_Coverage {get; set;}
        public List<Sr_SE_Competitors>? Sr_Competitors {get; set;}
        public Sr_SE_Venue? Sr_Venue {get; set;}
        public Sr_SE_Conditions? Sr_Sport_Event_Conditions {get; set;}
    }
}