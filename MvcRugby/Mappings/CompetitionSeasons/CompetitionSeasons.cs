namespace MvcRugby.Mappings
{
    public class CompetitionSeasons
    {
        public string? generated_at { get; set; } // E.g: "2023-11-08T21:41:36+00:00"
        public List<CompetitionSeasonsDetails>? seasons { get; set; }
    }
}