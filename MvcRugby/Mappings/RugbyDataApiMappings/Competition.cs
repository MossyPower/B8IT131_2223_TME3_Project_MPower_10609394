namespace MvcRugby.Mappings
{
    public class RdAPI_Competitions
    {
        public int CompetitionId { get; set; } 
        public string? SrCompetitionId {get; set;}
        public string? CompetitionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Year { get; set; }
        public List<RdAPI_Fixture>? Fixtures { get; set; }
    }
}