namespace MvcRugby.Mappings
{
    public class RdAPI_Club
    {
        public int ClubId { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; }
        public List<RdAPI_Player>? Players { get; set; }
    }
}