namespace MvcRugby.Mappings
{
    public class RdAPI_Competitions
    {
        public int CompetitionId { get; set; }
        public string? Competition_Name { get; set; }
        public List<RdAPI_Fixture>? Fixtures { get; set; }
        public List<RdAPI_Club>? Clubs { get; set; }
    }
}