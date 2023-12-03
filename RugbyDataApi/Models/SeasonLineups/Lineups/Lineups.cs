namespace RugbyDataApi.Models
{
    public class Lineups
    {
        public SportEvent? sport_event {get; set;}
        public SportEventStatus? sport_event_status {get; set;}
        public SportEventLineups? lineups {get; set;}
    }
}