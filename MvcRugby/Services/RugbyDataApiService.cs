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

        [HttpPost]
        public async Task SaveSeasons(Season Season)
        {
            if(Season != null)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync<Season>("api/v1/season/", Season);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new ApplicationException("Error adding the Sport Radar seasons in the API.", ex);
                }
            }
            else
            {
                throw new Exception("Season cannot be null.");
            }
        }

        [HttpPost]
        public async Task SavePlayers(SeasonPlayer seasonPlayer)
        {
            if(seasonPlayer != null)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync<SeasonPlayer>("api/v1/seasonplayers/", seasonPlayer);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new ApplicationException("Error adding the Sport Radar seasons in the API.", ex);
                }
            }
            else
            {
                throw new Exception("Season cannot be null.");
            }
        }


        // *****************************************************************************************

        // COMPETITION MODEL ACTIONS
        
        [HttpGet]
        public async Task<IEnumerable<Competition>> GetAllCompetitions()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Competition>>("api/v1/competition/");
        }
        
        [HttpGet]
        public async Task<RdAPI_Competitions> GetCompetitionWithRelatedData(int id)
        {
            return await _httpClient.GetFromJsonAsync<RdAPI_Competitions>("api/v1/competition/withrelateddata");
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
        
        // FIXTURE MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<Fixture>> GetAllFixtures()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Fixture>>("api/v1/fixture/");
        }
        
        [HttpGet]
        public async Task<IEnumerable<Fixture>?> GetCompetitionFixtures(int id)
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
        
        // PLAYER LINEUP MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<PlayerLineup>> GetAllPlayerLineups()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerLineup>>("api/v1/playerlineup/");
        }
        
        [HttpGet]
        public async Task<PlayerLineup> GetPlayerLineupById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PlayerLineup>($"api/v1/playerlineup/{id}");
        }

        [HttpPost]
        public async Task AddPlayerLineup(PlayerLineup playerLineup)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<PlayerLineup>("api/v1/playerlineup/", playerLineup);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the player lineup in the API.", ex);
            }
        }

        public async Task EditPlayerLineupById(int id, PlayerLineup playerLineup)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<PlayerLineup>($"/api/v1/playerlineup/{id}", playerLineup);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the player lineup in the API.", ex);
            }
        }

        public async Task DeletePlayerLineupById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/playerlineup/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the player lineup in the API.", ex);
            }
        }

        // *****************************************************************************************
        
        // PLAYER STATISTICS MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<PlayerStatistics>> GetAllPlayersStatistics()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerStatistics>>("api/v1/playerstatistics/");
        }
        
        // [HttpGet]
        // public async Task<IEnumerable<PlayerStatistics>?> GetPlayersStatisticsByPlayerId(List<int> playerIds)
        // {
        //     return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerStatistics>>($"api/v1/playerstatistics/players/{playerIds}");
        // }

        [HttpGet]
        public async Task<PlayerStatistics> GetPlayerStatisticsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<PlayerStatistics>($"api/v1/playerstatistics/{id}");
        }

        [HttpPost]
        public async Task AddPlayerStatistics(PlayerStatistics playerStatistics)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<PlayerStatistics>("api/v1/playerstatistics/", playerStatistics);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the player in the API.", ex);
            }
        }

        public async Task EditPlayerStatisticsById(int id, PlayerStatistics playerStatistics)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<PlayerStatistics>($"/api/v1/playerStatistics/{id}", playerStatistics);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the player statistics in the API.", ex);
            }
        }

        public async Task DeletePlayerStatisticsById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/playerStatistics/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the player statistics in the API.", ex);
            }
        }  

        // *****************************************************************************************        
        
        // TEAM MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Team>>("api/v1/team/");
        }
        
        [HttpGet]
        public async Task<Team> GetTeamById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Team>($"api/v1/team/{id}");
        }

        [HttpPost]
        public async Task AddTeam(Team team)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Team>("api/v1/team/", team);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the team in the API.", ex);
            }
        }

        public async Task EditTeamById(int id, Team team)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<Team>($"/api/v1/team/{id}", team);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the team in the API.", ex);
            }
        }

        public async Task DeleteTeamById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/team/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the club in the API.", ex);
            }
        }

        // *****************************************************************************************
        
        // TEAM LINEUP MODEL ACTIONS
        [HttpGet]
        public async Task<IEnumerable<TeamLineup>> GetAllTeamLineups()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeamLineup>>("api/v1/teamlineup/");
        }
        
        [HttpGet]
        public async Task<TeamLineup> GetTeamLineupById(int id)
        {
            return await _httpClient.GetFromJsonAsync<TeamLineup>($"api/v1/teamlineup/{id}");
        }

        [HttpPost]
        public async Task AddTeamLineup(TeamLineup teamLineup)        
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<TeamLineup>("api/v1/teamlineup/", teamLineup);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error creating the team lineup in the API.", ex);
            }
        }

        public async Task EditTeamLineupById(int id, TeamLineup teamLineup)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<TeamLineup>($"/api/v1/teamlineup/{id}", teamLineup);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error editing the team lineup in the API.", ex);
            }
        }

        public async Task DeleteTeamLineupById(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/v1/teamlineup/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the team lineup in the API.", ex);
            }
        }        
    }     
}