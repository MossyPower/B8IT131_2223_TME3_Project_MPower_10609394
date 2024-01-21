using MvcRugby.Models;

public interface IRugbyDataApiService
{
    // COMPETITION ACTION METHODS
    Task<IEnumerable<Competition>?> GetAllCompetitions();
    Task<Competition>? GetCompetitionById(int id);
    Task AddCompetition(Competition competition);
    Task EditCompetitionById(int id, Competition competition);
    Task DeleteCompetitionById(int id);
    
    // CLUB ACTION METHODS
    Task<IEnumerable<Club>?> GetAllClubs();
    Task<Club>? GetClubById(int id);
    Task AddClub(Club club);
    Task EditClubById(int id, Club club);
    Task DeleteClubById(int id);

    // PLAYER ACTION METHODS
    Task<IEnumerable<Player>?> GetAllPlayers();
    Task<Player>? GetPlayerById(int id);
    Task AddPlayer(Player player);
    Task EditPlayerById(int id, Player player);
    Task DeletePlayerById(int id);

    // FIXTURE ACTION METHODS
    Task<IEnumerable<Fixture>?> GetAllFixtures();
    Task<Fixture>? GetFixtureById(int id);
    Task AddFixture(Fixture player);
    Task EditFixtureById(int id, Fixture player);
    Task DeleteFixtureById(int id);
    
    // FIXTURE STATISTICS ACTION METHODS
    Task<IEnumerable<FixtureStatistics>?> GetAllFixturesStatistics();
    Task<FixtureStatistics>? GetFixtureStatisticsById(int id);
    Task AddFixtureStatistics(FixtureStatistics player);
    Task EditFixtureStatisticsById(int id, FixtureStatistics player);
    Task DeleteFixtureStatisticsById(int id);
}