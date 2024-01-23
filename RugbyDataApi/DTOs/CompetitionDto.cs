namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class CompetitionDto
    {
        public int CompetitionId { get; set; }
        public string? Competition_Name { get; set; }
        public List<FixtureDto>? Fixtures { get; set; }
        public List<ClubDto>? Clubs { get; set; }
    }
}