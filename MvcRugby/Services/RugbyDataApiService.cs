using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using MvcRugby.Models;
using MvcRugby.Services;

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

        // SEASON MODEL ACTIONS
        
        // Get all Seasons
        // public async Task<IEnumerable<Season>?> GetSeasons()
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<Season>>("api/v1/seasons/");
        // }

        // Get Season by ID
        // public async Task<Season>? GetSeason(int id)
        // {
        //     return await _httpClient.GetFromJsonAsync<Season>($"api/v1/seasons/{id}");
        // }

        // Create Season
        // public async Task<Season> CreateSeason(Season season)
        // {
        //     await _httpClient.PostAsJsonAsync<Season>("api/v1/seasons/", season);
        // }

       // Edit Season
        // public async Task<Season> EditSeason(int id, Season season)
        // {

        //     HttpResponseMessage response = await _httpClient.PutAsJsonAsync<Season>($"api/v1/seasons/{id}", season);
            
        //     return await _httpClient.GetFromJsonAsync<Season>($"api/v1/seasons/{id}");
        // }

        // Delete Season
        // public async Task<Season> DeleteSeason(int id)
        // {
        //     await _httpClient.DeleteAsync($"api/v1/seasons/{id}");
        // }
        
        // CLUB MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Club>>("api/v1/club/");
        }
        
        [HttpGet]
        public async Task<Club> GetClubById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Club>($"api/v1/club/{id}");
        }

        [HttpPost]
        public async Task AddClub(Club club)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Club>("api/v1/club/", club);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the club in the API.", ex);
            }
        }

        public async Task EditClubById(int id, Club club)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Club>($"/api/v1/club/{id}", club);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the club in the API.", ex);
            }
        }

        public async Task DeleteClubById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/club/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the club in the API.", ex);
            }
        }


        // COMPETITION MODEL ACTIONS
        // public async Task<IEnumerable<Competition>?> GetCompetitions()
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<Competition>>("api/v1/competitions/");
        // }
        
        // COMPETITION-GAMES MODEL ACTIONS
        // public async Task<IEnumerable<Fixture>?> GetFixtures()
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<Fixture>>("api/v1/fixtures/");
        // } 
        
        // PLAYERS MODEL ACTIONS
        // public async Task<IEnumerable<Player>?> GetPlayers()
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<Player>>("api/v1/players/");
        // } 
        
        // PLAYER-STATISTICS MODEL ACTIONS
        // public async Task<IEnumerable<FixtureStatistics>?> GetFixtureStatistics()
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<FixtureStatistics>>("api/v1/fixturestatistics/");
        // }     
    }     
}