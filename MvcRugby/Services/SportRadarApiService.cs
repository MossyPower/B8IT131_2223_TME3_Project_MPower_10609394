using MvcRugby.Models;
using MvcRugby.Mappings;

namespace MvcRugby.Services
{
    public class SportRadarApiService : ISportRadarApiService
    {
        private readonly HttpClient _httpClient;
        private string API_KEY = ".json?api_key=gs7gsba9bhgtabs32wpuh3pw";

        public SportRadarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://api.sportradar.com/rugby-union/trial/v3/en/");
        }
        
        // Get Competitions
        public async Task<SeasonInfo?> GetSeasons() // "Seasons" is one of the the Sport Radar Api end point names
        {   
            return await _httpClient.GetFromJsonAsync<SeasonInfo>($"seasons"+API_KEY);
        }     

        //Get Competition Rounds
        public async Task<SeasonLineups?> GetSrSeasonLineups(string SeasonId) // "Season Lineups" is one of the the Sport Radar Api end point names
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups{API_KEY}");
        }

        //Get Player Statistics
        // public async Task<Players?> GetPlayerProfile(string? PlayerId) // "Player Profile" is one of the the Sport Radar Api end point names
        // {   
        //     return await _httpClient.GetFromJsonAsync<Players>($"players/{PlayerId}/profile{API_KEY}");
        // }
        public async Task<SeasonPlayersEndPoint?> GetPlayersBySeasonId(string SeasonId) // "Season Lineups" is one of the the Sport Radar Api end point names
        {   
            return await _httpClient.GetFromJsonAsync<SeasonPlayersEndPoint>($"seasons/{SeasonId}/players{API_KEY}");
        }

    }
}
