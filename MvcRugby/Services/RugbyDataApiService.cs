using MvcRugby.Mappings;

namespace MvcRugby.Services
{
    public class RugbyDataApiService : IRugbyDataApiService
    {
        private readonly HttpClient _httpClient;
        // private string API_KEY = ".json?api_key=r577fne89ddc78h7vc9zpq5v";

        public RugbyDataApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7286/");
        }
        
        // Get Competitions
        public async Task<SeasonInfo?> GetCompetitions()
        {   
            return await _httpClient.GetFromJsonAsync<SeasonInfo>("seasons");
        }     

        // Get Competition Rounds
        public async Task<SeasonLineups?> GetCompetitionRounds(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups");
        }
        
        // Get Competition Round Teams
        public async Task<SeasonLineups?> GetRoundLineup(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups");
        }

        // Get Player Statistics
        public async Task<Players?> GetPlayerStatistics(string? PlayerId)
        {   
            return await _httpClient.GetFromJsonAsync<Players>($"players/{PlayerId}/profile");
        }
    }
}
