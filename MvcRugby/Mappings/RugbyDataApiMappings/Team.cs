namespace MvcRugby.Mappings
{
    public class RdAPI_Team
    {
        public int TeamId { get; set; }
        public string? SrCompetitorId {get; set;}
        public string? TeamName { get; set; }
        public string? Country { get; set; }
        public List<RdAPI_Player>? Players { get; set; }
        public List<RdAPI_TeamLineup>? TeamLineups { get; set; }
    }
}