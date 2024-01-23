namespace MvcRugby.Mappings
{
    public class RdAPI_Player
    {
        public int PlayerId { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }

        public List<RdAPI_FixtureStatistics>? FixturesStatistics { get; set; }
    }
}