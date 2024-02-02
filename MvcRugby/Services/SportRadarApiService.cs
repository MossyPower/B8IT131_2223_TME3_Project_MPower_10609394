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

        // Get/Api: Competition players
        public async Task<SeasonPlayersEndPoint?> GetSrSeasonPlayers(string SeasonId) // Sportreadar Endpoint name "Season Players"
        {   
            return await _httpClient.GetFromJsonAsync<SeasonPlayersEndPoint>($"seasons/{SeasonId}/players{API_KEY}");
        }
        
        // Get/Api: Competition teams
        public async Task<SeasonTeamsEndpoint?> GetSrSeasonCompetitors(string SeasonId) // Sportreadar Endpoint name "Season Competitors"
        {   
            return await _httpClient.GetFromJsonAsync<SeasonTeamsEndpoint>($"seasons/{SeasonId}/competitors{API_KEY}");
        }
        
        // Get/Api: Competition fixtures
        public async Task<SeasonLineupsEndpoint?> GetSrSeasonLineups(string SeasonId) // Sportreadar Endpoint name "Season Competitors"
        {   
            return await _httpClient.GetFromJsonAsync<SeasonLineupsEndpoint>($"seasons/{SeasonId}/lineups{API_KEY}");
        }
    }
}
