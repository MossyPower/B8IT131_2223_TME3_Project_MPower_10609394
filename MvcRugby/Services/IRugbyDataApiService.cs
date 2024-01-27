using Microsoft.AspNetCore.Mvc.Rendering; //Required for SelectList
using MvcRugby.Models;
using MvcRugby.Mappings;

public interface IRugbyDataApiService
{
    // SEASON ACTION METHODS
    Task SaveSeasons(Season Season);
    Task SavePlayers(SeasonPlayer Player);

    // **********************************************   
    // 3rd Part Api Sport Radar End-point Actions above
    // **********************************************

    // COMPETITION ACTION METHODS
    Task<IEnumerable<Competition>?> GetAllCompetitions();
    Task<RdAPI_Competitions> GetCompetitionWithRelatedData(int id);
    Task<Competition>? GetCompetitionById(int id);
    Task AddCompetition(Competition competition);
    Task EditCompetitionById(int id, Competition competition);
    Task DeleteCompetitionById(int id);


    // FIXTURE ACTION METHODS
    Task<IEnumerable<Fixture>?> GetAllFixtures();
    Task<IEnumerable<Fixture>?> GetCompetitionFixtures(int id);
    Task<Fixture>? GetFixtureById(int id);
    Task AddFixture(Fixture player);
    Task EditFixtureById(int id, Fixture player);
    Task DeleteFixtureById(int id);
    

    // PLAYER ACTION METHODS
    Task<IEnumerable<Player>?> GetAllPlayers();
    Task<Player>? GetPlayerById(int id);
    Task AddPlayer(Player player);
    Task EditPlayerById(int id, Player player);
    Task DeletePlayerById(int id);


    // PLAYER LINEUP ACTION METHODS
    Task<IEnumerable<PlayerLineup>?> GetAllPlayerLineups();
    Task<PlayerLineup>? GetPlayerLineupById(int id);
    Task AddPlayerLineup(PlayerLineup playerLineup);
    Task EditPlayerLineupById(int id, PlayerLineup playerLineup);
    Task DeletePlayerLineupById(int id); 

    // PLAYER STATISTICS ACTION METHODS
    Task<IEnumerable<PlayerStatistics>?> GetAllPlayersStatistics();
    // Task<IEnumerable<PlayerStatistics>?> GetPlayersStatisticsByPlayerId(List<int> PlayerIds);
    Task<PlayerStatistics>? GetPlayerStatisticsById(int id);
    Task AddPlayerStatistics(PlayerStatistics player);
    Task EditPlayerStatisticsById(int id, PlayerStatistics player);
    Task DeletePlayerStatisticsById(int id);


    // TEAM ACTION METHODS
    Task<IEnumerable<Team>?> GetAllTeams();
    Task<Team>? GetTeamById(int id);
    Task AddTeam(Team Team);
    Task EditTeamById(int id, Team Team);
    Task DeleteTeamById(int id);


    // TEAM LINEUPS ACTION METHODS
    Task<IEnumerable<TeamLineup>?> GetAllTeamLineups();
    Task<TeamLineup>? GetTeamLineupById(int id);
    Task AddTeamLineup(TeamLineup player);
    Task EditTeamLineupById(int id, TeamLineup player);
    Task DeleteTeamLineupById(int id);
}