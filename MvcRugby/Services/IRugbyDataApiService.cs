using Microsoft.AspNetCore.Mvc.Rendering; //Required for SelectList
using MvcRugby.Models;
using MvcRugby.Mappings;

public interface IRugbyDataApiService
{
    // SEASON ACTION METHODS
    Task SaveSeasons(Season Season); // Removed as no longer relevant
    Task SavePlayers(SeasonPlayer Player); // Need to add a link between players and competition to line up with 3rd party API

    // **********************************************   
    // 3rd Party Api Sport Radar End-point Actions above
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
    Task<IEnumerable<Fixture>?> GetRoundFixtures(int competitionId, int roundNumber);
    Task<Fixture>? GetFixtureById(int id);
    Task<RdAPI_Fixture>? GetFixtureWithRelatedData(int id);
    Task AddFixture(Fixture player);
    Task EditFixtureById(int id, Fixture player);
    Task DeleteFixtureById(int id);
    

    // PLAYER ACTION METHODS
    Task<IEnumerable<Player>?> GetAllPlayers();
    Task<Player>? GetPlayerById(int id);
    Task <IEnumerable<Player>>? GetAllFixturePlayersById(List<int> ids);
    Task<IEnumerable<Player>>? GetRoundPlayers(List<int> roundPlayersIds);
    Task AddPlayer(Player player);
    Task EditPlayerById(int id, Player player);
    Task DeletePlayerById(int id);


    // PLAYER LINEUP ACTION METHODS
    Task<IEnumerable<PlayerLineup>?> GetAllPlayerLineups();
    Task<IEnumerable<PlayerLineup>>? GetFixturePlayerLineups(int id);
    Task <IEnumerable<PlayerLineup>> GetAllPlayerLineupsById(int id);
    Task<IEnumerable<PlayerLineup>>? GetRoundPlayerLineups(List<int> teamLineupIds);
    Task<PlayerLineup>? GetPlayerLineupById(int id);
    Task<IEnumerable<PlayerLineup>>? GetPlayerLineupByTeamLineupId(int id);
    Task AddPlayerLineup(PlayerLineup playerLineup);
    Task EditPlayerLineupById(int id, PlayerLineup playerLineup);
    Task DeletePlayerLineupById(int id); 

    // PLAYER STATISTICS ACTION METHODS
    Task<IEnumerable<PlayerStatistics>?> GetAllPlayersStatistics();
    Task<PlayerStatistics>? GetPlayerFixtureStatistics(int playerId, int fixtureId);
    Task<PlayerStatistics>? GetPlayerStatisticsById(int id);
    Task AddPlayerStatistics(PlayerStatistics player);
    Task EditPlayerStatisticsById(int id, PlayerStatistics player);
    Task DeletePlayerStatisticsById(int id);


    // TEAM ACTION METHODS
    Task<IEnumerable<Team>?> GetAllTeams();
    Task<Team>? GetTeamById(int id);
    Task<IEnumerable<Team>>? GetFixtureTeams(int id);
    Task<IEnumerable<Team>>? GetRoundTeams(List<int> roundTeamsIds);
    Task AddTeam(Team Team);
    Task EditTeamById(int id, Team Team);
    Task DeleteTeamById(int id);


    // TEAM LINEUPS ACTION METHODS
    Task<IEnumerable<TeamLineup>?> GetAllTeamLineups();
    Task<TeamLineup>? GetTeamLineupById(int id);
    Task<IEnumerable<TeamLineup>>? GetFixtureTeamLineups(int id);
    Task<IEnumerable<TeamLineup>>? GetRoundTeamLineups(List<int> fixtureIds);
    Task AddTeamLineup(TeamLineup teamLineup);
    Task EditTeamLineupById(int id, TeamLineup teamLineup);
    Task DeleteTeamLineupById(int id);
}