namespace MvcRugby.Mappings
{
    public class SeasonTeamsEndpoint
    {
        public DateTime? generated_at { get; set; } // E.g: "2023-11-08T21:41:36+00:00"
        public List<Season_Competitor>? Season_Competitors { get; set; }
    }
}