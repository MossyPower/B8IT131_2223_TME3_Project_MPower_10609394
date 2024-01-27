namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class FixtureDto
    {
        public int FixtureId { get; set; }
        public string? SrSportEventId {get; set;}
        public int RoundNumber { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public List<TeamLineupDto>? TeamLineups { get; set; }
        public List<PlayerStatisticsDto>? PlayersStatistics { get; set; }
    }
}