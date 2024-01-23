namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class FixtureDto
    {
        public int FixtureId { get; set; }
        public string? SportRadar_Id { get; set; }
        public int? Round_Number { get; set; }
        public string? Fixture_Date { get; set; }
        public List<FixtureStatisticsDto>? FixturesStatistics { get; set; }
    }
}