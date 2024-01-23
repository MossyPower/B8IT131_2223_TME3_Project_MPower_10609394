namespace MvcRugby.Mappings
{
    public class RdAPI_Fixture
    {
        public int FixtureId { get; set; }
        public string? SportRadar_Id { get; set; }
        public int? Round_Number { get; set; }
        public string? Fixture_Date { get; set; }
        public List<RdAPI_FixtureStatistics>? FixturesStatistics { get; set; }
    }
}