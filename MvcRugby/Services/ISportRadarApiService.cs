using MvcRugby.Mappings;
public interface ISportRadarApiService
{
    //Get Sport Radar Api End-point: Seasons
    Task<SeasonInfo?> GetSeasons();
    
    //Get Sport Radar Api End-point: Player Profile
    //Task<Players?> GetPlayerProfile(string PlayerId);
    
    //Get Sport Radar Api End-point: Season Players
    Task<SeasonPlayersEndPoint?>GetSrSeasonPlayers(string SeasonId);
    
    //Get Sport Radar Api End-point: Season Competitors (aka; Competition teams)
    Task<SeasonTeamsEndpoint?>GetSrSeasonCompetitors(string SeasonId);
    
    //Get Sport Radar Api End-point: Season Lineup (aka; Competition fixtures)
    Task<SeasonLineupsEndpoint> GetSrSeasonLineups(string SeasonId);
}