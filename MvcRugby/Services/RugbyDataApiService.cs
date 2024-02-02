using Microsoft.AspNetCore.Mvc;
using MvcRugby.Models;
using MvcRugby.Mappings;

namespace MvcRugby.Services
{
    public class RugbyDataApiService : IRugbyDataApiService
    {
        private readonly ILogger<RugbyDataApiService> _logger;
        private string BASE_URL = "http://localhost:5217/";
        private readonly HttpClient _httpClient;
        public RugbyDataApiService(ILogger<RugbyDataApiService> logger, HttpClient httpClient)
        {
            _logger = logger;
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
                    var response = await _httpClient.PostAsJsonAsync<SeasonPlayer>("api/v1/player/", seasonPlayer);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new ApplicationException("Error adding the Sport Radar players in the API.", ex);
                }
            }
            else
            {
                throw new Exception("Players cannot be null.");
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
                var response = await _httpClient.DeleteAsync($"/api/v1/competition/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting the competition in the API.", ex);
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
        public async Task<IEnumerable<Fixture>?> GetRoundFixtures(int competitionId, int roundNumber)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Fixture>>($"api/v1/fixture/competition/{competitionId}/round/{roundNumber}");
        }

        [HttpGet]
        public async Task<Fixture> GetFixtureById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Fixture>($"api/v1/fixture/{id}");
        }

        [HttpGet]
        public async Task<RdAPI_Fixture> GetFixtureWithRelatedData(int id)
        {
            return await _httpClient.GetFromJsonAsync<RdAPI_Fixture>("api/v1/fixture/withrelateddata");
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

        [HttpGet]
        public async Task<IEnumerable<Player>> GetAllFixturePlayersById(List<int> ids)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Player>>($"api/v1/player/allfixtureplayers?ids={string.Join(",", ids)}");
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> GetRoundPlayers(List<int> roundPlayersIds)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Player>>($"api/v1/player/roundplayers?roundPlayersIds={string.Join("&roundPlayersIds=", roundPlayersIds)}");
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
        
        [HttpGet]
        public async Task<IEnumerable<PlayerLineup>> GetPlayerLineupByTeamLineupId(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerLineup>>($"api/v1/playerlineup/roundplayerlineups/{id}");
        }

        [HttpGet]
        public async Task <IEnumerable<PlayerLineup>> GetAllPlayerLineupsById(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerLineup>>($"api/v1/playerlineup/teamlineup/{id}");
        }
        
        [HttpGet]
        public async Task<IEnumerable<PlayerLineup>> GetRoundPlayerLineups(List<int> teamLineupIds)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerLineup>>($"api/v1/playerlineup/round?teamlineupids={string.Join("&teamlineupids=", teamLineupIds)}");
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

        [HttpGet]
        public async Task<IEnumerable<PlayerLineup>> GetFixturePlayerLineups(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PlayerLineup>>($"api/v1/playerlineup/fixture/{id}");
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
        
        [HttpGet]
        public async Task<PlayerStatistics> GetPlayerFixtureStatistics(int playerId, int fixtureId)
        {
            return await _httpClient.GetFromJsonAsync<PlayerStatistics>($"api/v1/playerstatistics/player/{playerId}/fixture/{fixtureId}");
        }

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
            return await _httpClient.GetFromJsonAsync<IEnumerable<Team>>("api/v1/team");
        }

        [HttpGet]
        public async Task<Team> GetTeamById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Team>($"api/v1/team/{id}");
        }

        [HttpGet("fixture/{id}")]
        public async Task<IEnumerable<Team>> GetFixtureTeams(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Team>>($"api/v1/team/fixture/{id}");
        }
        
        [HttpGet]
        public async Task<IEnumerable<Team>> GetRoundTeams(List<int> roundTeamsIds)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Team>>($"api/v1/team/roundteams?roundTeamsIds={string.Join("&roundTeamsIds=", roundTeamsIds)}");
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
                throw new ApplicationException("Error deleting the team in the API.", ex);
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
        
        [HttpGet]
        public async Task<IEnumerable<TeamLineup>> GetFixtureTeamLineups(int id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeamLineup>>($"api/v1/teamlineup/fixture/{id}");
        }

        [HttpGet]
        public async Task<IEnumerable<TeamLineup>> GetRoundTeamLineups(List<int> fixtureIds)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TeamLineup>>($"api/v1/teamlineup/fixtures?fixtureids={string.Join("&fixtureids=", fixtureIds)}");
        }

        [HttpPost]
        public async Task AddTeamLineup(TeamLineup teamLineup)        
        {
            _logger.LogInformation("SyncCompetitionTeamLineups payload successfully reached AddTeamLineup sevice task method");
            _logger.LogInformation($"TeamLineup Data: {Newtonsoft.Json.JsonConvert.SerializeObject(teamLineup)}");
            
            
            try
            {
                var response = await _httpClient.PostAsJsonAsync<TeamLineup>("api/v1/teamlineup/", teamLineup);
                response.EnsureSuccessStatusCode();
                
                // Log the response details
                _logger.LogInformation($"API Response: {await response.Content.ReadAsStringAsync()}");
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.LogError($"Inner Exception: {ex.InnerException.Message}");
                }
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