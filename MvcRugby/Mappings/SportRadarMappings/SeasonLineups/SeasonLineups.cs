namespace MvcRugby.Mappings
{
    public class SeasonLineupsEndpoint
    {
        public string? generated_at { get; set; } // E.g: "2023-11-08T19:42:06+00:00"
        public List<Lineups>? lineups { get; set; } 
    }
}