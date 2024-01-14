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
        public async Task<SeasonInfo?> GetCompetitions()
        {   
            return await _httpClient.GetFromJsonAsync<SeasonInfo>($"seasons"+API_KEY);
        }     

        //Get Competition Rounds
        public async Task<SeasonLineups?> GetCompetitionRounds(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups{API_KEY}");
        }
        
        //Get Competition Round Teams
        public async Task<SeasonLineups?> GetRoundLineup(string? SeasonId)
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups{API_KEY}");
        }

        //Get Player Statistics
        public async Task<Players?> GetPlayerStatistics(string? PlayerId)
        {   
            return await _httpClient.GetFromJsonAsync<Players>($"players/{PlayerId}/profile{API_KEY}");
        }
    }
}
