// Implement the interface of ISportRadarService and its method GetCompetitions(). Builds methods you are declaring

using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using MvcRugby.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
//using Newtonsoft.Json;

namespace MvcRugby.Services
{
    public class SportRadarApiService : ISportRadarApiService
    {
        private readonly HttpClient _httpClient;
        private string API_KEY = ".json?api_key=r577fne89ddc78h7vc9zpq5v";

        public SportRadarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://api.sportradar.com/rugby-union/trial/v3/en/");
        }
        
        // Get Competitions
        public async Task<PrimaryFeeds?> GetCompetitions()
        {   
            return await _httpClient.GetFromJsonAsync<PrimaryFeeds>("competitions"+API_KEY);
        }

        // Get Seasons
        public async Task<SeasonInfo?> GetSeasons()
        {   
            return await _httpClient.GetFromJsonAsync<SeasonInfo>("seasons"+API_KEY);
        }        

        //Geat Season Lineups
        public async Task<SeasonLineups?> GetSeasonLineups(string? SeasonId)
        {   
            // Sample Request URI: http://api.sportradar.us/rugby-union/trial/v3/en/seasons/sr:season:59620/lineups.json?api_key=r577fne89ddc78h7vc9zpq5v
            return await _httpClient.GetFromJsonAsync<SeasonLineups>($"seasons/{SeasonId}/lineups{API_KEY}");
        }

        // GetPlayers()

    }
}
