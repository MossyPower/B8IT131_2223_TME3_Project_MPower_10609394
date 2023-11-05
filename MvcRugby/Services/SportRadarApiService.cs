// Implement the interface of ISportRadarService and its method GetCompetitions(). Builds methods you are declaring

using Microsoft.AspNetCore.Http;
using MvcRugby.Mappings;

namespace MvcRugby.Services
{
    public class SportRadarApiService : ISportRadarApiService
    {
        private readonly HttpClient _httpClient;
        private string API_KEY = "r577fne89ddc78h7vc9zpq5v";

        public SportRadarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://api.sportradar.com/");
        }
        public async Task<PrimaryFeeds?> GetCompetitions()
        {   
            return await _httpClient.GetFromJsonAsync<PrimaryFeeds>("rugby-union/trial/v3/en/competitions.json?api_key="+API_KEY);
        }
    }
}
