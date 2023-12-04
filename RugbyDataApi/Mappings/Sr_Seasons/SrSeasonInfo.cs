namespace RugbyDataApi.Mappings
{
    public class SrSeasonInfo
    {
        public DateTime? SrGenerated_at { get; set; } // E.g: "2023-11-08T21:41:36+00:00"
        public List<SrSeasons>? SrSeasons { get; set; }
    }
}