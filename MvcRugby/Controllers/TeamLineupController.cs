using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcRugby.Data;
using MvcRugby.Models;
using MvcRugby.ViewModels;
using MvcRugby.Services;

namespace MvcRugby.Controllers
{
    public class TeamLineupController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RugbyDataApiService _rugbyDataApiService;
        private readonly IHttpClientFactory _clientFactory;

        public TeamLineupController(ILogger<TeamController> logger, ApplicationDbContext context, RugbyDataApiService rugbyDataApiService, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _context = context;
            _rugbyDataApiService = rugbyDataApiService;
            _clientFactory = clientFactory;
        }
        
        // GET: Fixture TeamLineups
        [HttpGet]
        public async Task<IActionResult> Index(int competitionId, int fixtureId)
        {
            // 1.) Fetch required data from the Api:

            // 1.1) fetch competition data
            var competition = await _rugbyDataApiService.GetCompetitionById(competitionId);
            
            // 1.2) fetch fixture data
            var fixture = await _rugbyDataApiService.GetFixtureById(fixtureId);

            // 1.3) fetch home & away team lineups by Fixture Id
            
            // fetch a list of all team lineups by fixtureID (includes both home and away teams)
            var teamLineups = await _rugbyDataApiService.GetFixtureTeamLineups(fixtureId);
            
            // seperate the Team lineups into home and away, using the Designation attribute
            var homeTeamLineup = new TeamLineup();
            var awayTeamLineup = new TeamLineup();

            foreach(var teamLineup in teamLineups)
            {
                if (teamLineup.Designation == "Home")
                {
                    homeTeamLineup = teamLineup;
                }
                else
                {
                    awayTeamLineup = teamLineup;
                }
            }
            
            // fetch Teams using TeamId from each home & away Team Lineup
            var homeTeam = await _rugbyDataApiService.GetTeamById(homeTeamLineup.TeamId); //e.g.: Munster
            var awayTeam = await _rugbyDataApiService.GetTeamById(awayTeamLineup.TeamId); //e.g.: The Sharks
            
            // fetch all Player Lineups by TeamLineupId, returns list of player Lineups, for home and away teams
            var homePlayerLineups = await _rugbyDataApiService.GetAllPlayerLineupsById(homeTeamLineup.TeamLineupId);           
            var awayPlayerLineups = await _rugbyDataApiService.GetAllPlayerLineupsById(awayTeamLineup.TeamLineupId);
            
            // Order the playerLineups by Jersey number
            var sortedHomePlayerLineups = homePlayerLineups.OrderBy(player => player.JerseyNumber).ToList(); //OrderBy returns IEnum, use .ToList() to cast to list (per ViewModel) 
            var sortedAwayPlayerLineups = awayPlayerLineups.OrderBy(player => player.JerseyNumber).ToList();

            // 1.4) Fetch a list of home & away players using the PlayerId in the sorted player lineups                     
            
            var homePlayers = new List<Player>();
            foreach (var homePlayer in sortedHomePlayerLineups)
            {
                var homePlayerId = homePlayer.PlayerId;
                var homePlayerForLineup = await _rugbyDataApiService.GetPlayerById(homePlayerId);
                homePlayers.Add(homePlayerForLineup);
            }
            
            var awayPlayers = new List<Player>();
            foreach (var awayPlayer in sortedAwayPlayerLineups)
            {
                var awayPlayerId = awayPlayer.PlayerId;
                var awayPlayerForLineup = await _rugbyDataApiService.GetPlayerById(awayPlayerId);
                awayPlayers.Add(awayPlayerForLineup);
            }


            //2.) data to viewmodel from above variables
            var ViewModel = new FixtureLineupViewModel()
            {
                
                Competition = new Competition()
                {
                    CompetitionName = competition.CompetitionName,
                    CompetitionId = competitionId,
                },
                
                Fixture = new Fixture()
                {
                    FixtureId = fixtureId,
                    SrSportEventId = fixture.SrSportEventId,
                    RoundNumber = fixture.RoundNumber,
                    StartTime = fixture.StartTime,
                    Status = fixture.Status,
                    HomeScore = fixture.HomeScore,
                    AwayScore = fixture.AwayScore,
                },

                //TeamLineup = teamLineups,
                HomeTeamLineup = homeTeamLineup,  
                AwayTeamLineup = awayTeamLineup,  

                //PlayerLineup = playerLineups,
                HomePlayerLineups = sortedHomePlayerLineups,
                AwayPlayerLineups = sortedAwayPlayerLineups,
                
                //Players = players,
                HomePlayers = homePlayers,
                AwayPlayers = awayPlayers,

                //Teams = teams,
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
            };
            
            return View(ViewModel);
        }

        // GET: TeamLineups/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));  
        }

        // GET: teamLineup/Create
        [HttpGet]
        public async Task<IActionResult> Create(int competitionId, int fixtureId)
        {
            var ViewModel = new CreateTeamLineupViewModel()
            {
                CompetitionId = competitionId,
                TeamLineup = new TeamLineup{FixtureId = fixtureId}
            };
            
            // add competitions dropdown
            await TeamDropdownList();

            return View(ViewModel);
        }

        // POST: teamLineupss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("TeamLineup.Designation, TeamLineup.FixtureId, TeamLineup.TeamId")]
        public async Task<IActionResult> CreateTeamLineup(CreateTeamLineupViewModel viewModel, int id)
        {
            _logger.LogInformation("TeamLineupController, Create method invoked");
            if (viewModel.TeamLineup != null)
            {
                _logger.LogInformation($"Fixture data being posted: {Newtonsoft.Json.JsonConvert.SerializeObject(viewModel.TeamLineup)}");
                if (ModelState.IsValid)
                {
                    await _rugbyDataApiService.AddTeamLineup(viewModel.TeamLineup);
                    _logger.LogInformation($": viewData information: {Newtonsoft.Json.JsonConvert.SerializeObject(viewModel)}");

                    return RedirectToAction("Index", "Fixture", new { competitionId = viewModel.CompetitionId });
                }
            }
            else
            {
                _logger.LogInformation("TeamLineup data is null");
            }

            return RedirectToAction("Index", "Fixture", new { competitionId = viewModel.CompetitionId });
            
        }
        
        // GET: teamLineupss/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));
        }

        // POST: teamLineupss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("TeamLineupId, Designation, FixtureId, TeamId")] int id, TeamLineup teamLineups)
        {
            if (id != teamLineups.TeamLineupId)
            {
                return BadRequest();
            }
            await _rugbyDataApiService.EditTeamLineupById(id, teamLineups);
            return RedirectToAction("Details", new { id = teamLineups.TeamLineupId });
        }

        // GET: teamLineupss/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _rugbyDataApiService.GetTeamLineupById(id));
        }

        // POST: teamLineupss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rugbyDataApiService.DeleteTeamLineupById(id);
            return RedirectToAction("Index");
        }

        // Create Dropdown for linked relational model; Team
        private async Task TeamDropdownList()
        {
            var teams = await _rugbyDataApiService.GetAllTeams();

            ViewBag.teams = new SelectList(teams, "TeamId", "TeamName");
        }
    }
}
