using MvcRugby.Mappings;
public interface ISportRadarApiService
{
    Task<PrimaryFeeds?> GetCompetitions();

    Task<SeasonInfo?> GetSeasons();
    
    Task<SeasonLineups?> GetSeasonLineups(string? SeasonId);
    
    //Task<SeasonInfo?> GetLatestSeasons();
}