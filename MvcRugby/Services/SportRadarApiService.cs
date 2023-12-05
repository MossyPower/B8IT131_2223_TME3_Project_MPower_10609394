using MvcRugby.Mappings;

namespace MvcRugby.Services
{
    public class SportRadarApiService : ISportRadarApiService
    {
        private readonly HttpClient _httpClient;
        private string API_KEY = ".json?api_key=r577fne89ddc78h7vc9zpq5v";

        public SportRadarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://api.sportradar.com/rugby-union/trial/v3/en");
        }
        
        // Get Competitions
        public async Task<Sr_Season_Info?> GetCompetitions()
        {   
            return await _httpClient.GetFromJsonAsync<Sr_Season_Info>("/seasons"+API_KEY);
        }     

        // Get Competition Rounds
        public async Task<Sr_Season_Lineups?> GetCompetitionRounds(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<Sr_Season_Lineups>($"/seasons/{SeasonId}/lineups{API_KEY}");
        }
        
        // Get Competition Round Teams
        public async Task<Sr_Season_Lineups?> GetRoundLineup(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<Sr_Season_Lineups>($"/seasons/{SeasonId}/lineups{API_KEY}");
        }

        // Get Player Statistics
        public async Task<Players?> GetPlayerStatistics(string? PlayerId)
        {   
            return await _httpClient.GetFromJsonAsync<Players>($"/players/{PlayerId}/profile{API_KEY}");
        }
    }
}
