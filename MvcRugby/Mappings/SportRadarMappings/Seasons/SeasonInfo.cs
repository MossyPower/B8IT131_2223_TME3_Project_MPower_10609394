namespace MvcRugby.Mappings
{
    public class SeasonInfo
    {
        public DateTime? generated_at { get; set; } // E.g: "2023-11-08T21:41:36+00:00"
        public List<Seasons>? seasons { get; set; }
    }
}