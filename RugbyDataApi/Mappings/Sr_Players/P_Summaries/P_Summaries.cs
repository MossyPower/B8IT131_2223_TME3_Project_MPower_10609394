namespace RugbyDataApi.Mappings
{
    public class P_Summaries
    {
        public PS_SportEvent? sport_event { get; set; } // E.g: "2023-11-08T21:41:36+00:00"
        public PS_SportEventStatus? summaries { get; set; }
        public PS_Statistics? statistics { get; set; }
    }
}