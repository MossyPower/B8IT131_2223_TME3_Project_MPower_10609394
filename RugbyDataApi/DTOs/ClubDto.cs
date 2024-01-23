namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class ClubDto
    {
        public int ClubId { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; }
        public List<PlayerDto>? Players { get; set; }
    }
}