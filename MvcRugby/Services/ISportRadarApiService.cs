using MvcRugby.Mappings;
public interface ISportRadarApiService
{
    //Get Sport Radar Api End-point: Seasons
    Task<SeasonInfo?> GetSeasons();
    
    //Get Sport Radar Api End-point: Season Lineups
    Task<SeasonLineups?> GetSrSeasonLineups(string? SeasonId);

    //Get Sport Radar Api End-point: Player Profile
    Task<Players?> GetPlayerProfile(string? PlayerId);
}