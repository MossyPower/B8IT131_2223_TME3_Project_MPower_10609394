using MvcRugby.Models;

public interface IRugbyDataApiService
{
    Task<IEnumerable<Club>?> GetClubs();
    Task<IEnumerable<Season>?> GetSeasons();
    Task<IEnumerable<Competition>?> GetCompetitions();
    Task<IEnumerable<CompetitionRound>?> GetCompetitionRounds();
    Task<IEnumerable<CompetitionGame>?> GetCompetitionGames();
    Task<IEnumerable<MatchDayTeam>?> GetMatchDayTeams();
    Task<IEnumerable<Player>?> GetPlayers();
    Task<IEnumerable<PlayerMatchStatistics>?> GetPlayerMatchStatistics();
}