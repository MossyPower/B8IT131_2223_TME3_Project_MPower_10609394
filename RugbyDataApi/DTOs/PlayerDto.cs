namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }

        public List<FixtureStatisticsDto>? FixturesStatistics { get; set; }
    }
}