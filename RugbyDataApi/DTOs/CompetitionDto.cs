namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class CompetitionDto
    {
        public int CompetitionId { get; set; } 
        public string? SrCompetitionId {get; set;}
        public string? CompetitionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Year { get; set; }
        public List<FixtureDto>? Fixtures { get; set; }
    }
}