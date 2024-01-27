namespace MvcRugby.Mappings
{
    public class RdAPI_Fixture
    {
        public int FixtureId { get; set; }
        public string? SrSportEventId {get; set;}
        public int RoundNumber { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public List<RdAPI_TeamLineup>? TeamLineups { get; set; }
        public List<RdAPI_PlayerStatistics>? PlayersStatistics { get; set; }
    }
}