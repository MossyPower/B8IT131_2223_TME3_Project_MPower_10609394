using RugbyDataApi.Mappings;
public interface ISportRadarApiService
{
    // Get Competitions
    Task<SrSeasonInfo?> GetCompetitions();
    
    // Get Competition Rounds
    Task<Sr_Season_Lineups?> GetCompetitionRounds(string? SeasonId);
    
    // Get Competition Round Teams
    Task<Sr_Season_Lineups?> GetRoundLineup(string? SeasonId);

    // Get Player Statistics
    Task<Players?> GetPlayerStatistics(string? PlayerId);
}