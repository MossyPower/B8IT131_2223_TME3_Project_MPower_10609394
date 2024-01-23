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
using MvcRugby.Mappings;

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

        // *****************************************************************************************
        
        // COMPETITION MODEL ACTIONS
        
        [HttpGet]
        public async Task<IEnumerable<Competition>> GetAllCompetitions()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Competition>>("api/v1/competition/");
        }
        
        [HttpGet]
        public async Task<RdAPI_Competitions> AllCompsWithRelatedData()
        {
            return await _httpClient.GetFromJsonAsync<RdAPI_Competitions>("api/v1/competition/withRelatedData");
        }
               
        
        [HttpGet]
        public async Task<Competition> GetCompetitionById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Competition>($"api/v1/competition/{id}");
        }

        [HttpPost]
        public async Task AddCompetition(Competition competition)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Competition>("api/v1/competition/", competition);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the competition in the API.", ex);
            }
        }
        
        //[HttpPut]
        public async Task EditCompetitionById(int id, Competition competition)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Competition>($"/api/v1/competition/{id}", competition);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the competition in the API.", ex);
            }
        }

        //[HttpDelete]
        public async Task DeleteCompetitionById(int id)
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

        // *****************************************************************************************        
        
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

        // *****************************************************************************************
        
        // PLAYER MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Player>>("api/v1/player/");
        }
        
        [HttpGet]
        public async Task<Player> GetPlayerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Player>($"api/v1/player/{id}");
        }

        [HttpPost]
        public async Task AddPlayer(Player player)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Player>("api/v1/player/", player);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the player in the API.", ex);
            }
        }

        public async Task EditPlayerById(int id, Player player)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Player>($"/api/v1/player/{id}", player);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the player in the API.", ex);
            }
        }

        public async Task DeletePlayerById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/player/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the player in the API.", ex);
            }
        }
        
        // *****************************************************************************************
        
        // FIXTURE MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<Fixture>> GetAllFixtures()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Fixture>>("api/v1/fixture/");
        }
        
        [HttpGet]
        public async Task<IEnumerable<Fixture>?> GetAllFixturesByCompetitionId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Fixture>>($"api/v1/fixture/competition/{id}");
        }

        [HttpGet]
        public async Task<Fixture> GetFixtureById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Fixture>($"api/v1/fixture/{id}");
        }

        [HttpPost]
        public async Task AddFixture(Fixture fixture)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Fixture>("api/v1/fixture/", fixture);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the fixture in the API.", ex);
            }
        }

        public async Task EditFixtureById(int id, Fixture fixture)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Fixture>($"/api/v1/fixture/{id}", fixture);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the fixture in the API.", ex);
            }
        }

        public async Task DeleteFixtureById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/fixture/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the fixture in the API.", ex);
            }
        }
        
        // *****************************************************************************************
        
        // FIXTURE STATISTICS MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<FixtureStatistics>> GetAllFixturesStatistics()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FixtureStatistics>>("api/v1/fixtureStatistics/");
        }
        
        // [HttpGet]
        // public async Task<IEnumerable<FixtureStatistics>?> GetFixturesStatisticsByFixtureId(List<int> fixtureIds)
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<FixtureStatistics>>($"api/v1/fixtureStatistics/fixtures/{fixtureIds}");
        // }

        [HttpGet]
        public async Task<FixtureStatistics> GetFixtureStatisticsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<FixtureStatistics>($"api/v1/fixtureStatistics/{id}");
        }

        [HttpPost]
        public async Task AddFixtureStatistics(FixtureStatistics fixtureStatistics)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<FixtureStatistics>("api/v1/fixtureStatistics/", fixtureStatistics);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the fixture in the API.", ex);
            }
        }

        public async Task EditFixtureStatisticsById(int id, FixtureStatistics fixtureStatistics)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<FixtureStatistics>($"/api/v1/fixtureStatistics/{id}", fixtureStatistics);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the fixture statistics in the API.", ex);
            }
        }

        public async Task DeleteFixtureStatisticsById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/fixtureStatistics/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the fixture statistics in the API.", ex);
            }
        }  

    }     
}