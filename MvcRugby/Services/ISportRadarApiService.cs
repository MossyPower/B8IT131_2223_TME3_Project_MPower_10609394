using MvcRugby.Mappings;
public interface ISportRadarApiService
{
    // Get Competitions
    Task<SeasonInfo?> GetCompetitions();
    
    //Get Competition Rounds
    Task<SeasonLineups?> GetCompetitionRounds(string? SeasonId);
    
    //Get Competition Round Teams
    Task<SeasonLineups?> GetRoundLineup(string? SeasonId);

    //Get Player Statistics
    Task<Players?> GetPlayerStatistics(string? PlayerId);
}