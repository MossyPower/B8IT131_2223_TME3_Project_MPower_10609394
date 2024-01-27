namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string? SrCompetitorId {get; set;}
        public string? TeamName { get; set; }
        public string? Country { get; set; }
        public List<PlayerDto>? Players { get; set; }
        public List<TeamLineupDto>? TeamLineups { get; set; }
    }
}