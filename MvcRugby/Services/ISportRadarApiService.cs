using MvcRugby.Mappings;
public interface ISportRadarApiService
{
    Task<PrimaryFeeds?> GetCompetitions();
}