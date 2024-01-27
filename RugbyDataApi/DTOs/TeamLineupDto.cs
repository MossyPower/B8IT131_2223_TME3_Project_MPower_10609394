namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class TeamLineupDto
    {
        public int TeamLineupId { get; set; }
        public string? Designation {get; set;}
        public List<PlayerLineupDto>? PlayerLineups { get; set; }
    }
}