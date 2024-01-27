namespace MvcRugby.Mappings
{
    public class RdAPI_TeamLineup
    {
        public int TeamLineupId { get; set; }
        public string? Designation {get; set;}
        public List<RdAPI_PlayerLineup>? PlayerLineups { get; set; }
    }
}