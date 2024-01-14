using Microsoft.AspNetCore.Http;
using MvcRugby.Models;
using MvcRugby.Services;
using Microsoft.AspNetCore.Identity;

namespace MvcRugby.Services
{
    public class RugbyDataApiService : IRugbyDataApiService
    {
        private string BASE_URL = "http://localhost:5217/";
        private readonly HttpClient _httpClient;
        public RugbyDataApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }

        public async Task<IEnumerable<Club>?> GetClubs()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Club>>("api/v1/clubs/");
        }
        
        public async Task<IEnumerable<Season>?> GetSeasons()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Season>>("api/v1/seasons/");
        }
        
        public async Task<IEnumerable<Competition>?> GetCompetitions()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Competition>>("api/v1/competitions/");
        }

        public async Task<IEnumerable<CompetitionRound>?> GetCompetitionRounds()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CompetitionRound>>("api/v1/competitionrounds/");
        }

        public async Task<IEnumerable<CompetitionGame>?> GetCompetitionGames()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CompetitionGame>>("api/v1/competitiongames/");
        } 

        public async Task<IEnumerable<MatchDayTeam>?> GetMatchDayTeams()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MatchDayTeam>>("api/v1/matchdayteams/");
        } 

        public async Task<IEnumerable<Player>?> GetPlayers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Player>>("api/v1/players/");
        } 

        public async Task<IEnumerable<PlayerMatchStatistics>?> GetPlayerMatchStatistics()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerMatchStatistics>>("api/v1/playermatchstatistics/");
        }     
    }     
}