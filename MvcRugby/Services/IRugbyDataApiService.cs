using MvcRugby.Models;

public interface IRugbyDataApiService
{
    // CLUB ACTION METHODS
    Task<IEnumerable<Club>?> GetClubs();

    // SEASON ACTION METHODS
    // Task<IEnumerable<Season>?> GetSeasons();
    // Task<Season>? GetSeason(int id);
    // Task<Season>? CreateSeason(Season season);
    // Task<Season>? EditSeason(int id);
    // Task<Season>? DeleteSeason(int id);

    // COMPETITION ACTION METHODS
    Task<IEnumerable<Competition>?> GetCompetitions();
    Task<IEnumerable<Fixture>?> GetFixtures();
    Task<IEnumerable<FixtureStatistics>?> GetFixtureStatistics();
    Task<IEnumerable<Player>?> GetPlayers();

}