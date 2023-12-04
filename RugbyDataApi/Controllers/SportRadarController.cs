// This controller fetchs data from Sport Radar third-party API and stores in locally only. 
// Includes an automated background service to complete this.
// Background service restricts number of calls per second / month to comply with third-party call limits.
// This controller has no interaction with the MvcRugby App 

// Start background service / fect & store methods here
// Assumed one required for each end point in the Sports Radar Api, i.e.: 
// Seasons
// SeasonLineup
// Players ==> this should be changed to match results
//    ^^^^ Save each players statistics to a seperate mode in the local database

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using RugbyDataApi.Services;
using RugbyDataApi.Models;
using RugbyDataApi.Data;
using RugbyDataApi.Mappings;

namespace MvcRugby.Controllers
{
    // [Authorize]
    public class SportRadarController : Controller
    {       
        //Create an instance of the SportRadarApiService class
    
        private readonly RugbyDataDbContext _rugbyDataDbContext;
        private readonly SportRadarApiService _sportRadarApiService;
    
        public SportRadarController(RugbyDataDbContext rugbyDataDbContext, SportRadarApiService sportRadarApiService)
        {
            _rugbyDataDbContext = rugbyDataDbContext;
            _sportRadarApiService = sportRadarApiService;
        }

        // Sync Competitions Info from Sport Radar Api
        public async Task<IActionResult> SyncSeasons()
        {
            var seasonsFromApi = await _sportRadarApiService.GetCompetitions();
            
            // Assuming seasonInfo is not null and contains a list of seasons
            List<Seasons> seasonsModel = new List<Seasons>();
            
            foreach (var srSeasons in seasonsFromApi.SrSeasons)
            {
                var existingSeason = _rugbyDataDbContext.seasons.FirstOrDefault(s => s.id == srSeasons.id);

                if (existingSeason == null)
                {
                    seasonsModel.Add(new Seasons{
                        id = srSeasons.id,
                        name = srSeasons.name,
                        start_date = srSeasons.start_date,
                        end_date = srSeasons.end_date,
                        year = srSeasons.year,
                        competition_id = srSeasons.competition_id
                    });
                }
            }
            
            // Add the entire collection to the DbContext
            _rugbyDataDbContext.seasons.AddRange(seasonsModel);

            // Save changes once, after adding all seasons
            await _rugbyDataDbContext.SaveChangesAsync();

            return Ok("Data synced successfully.");
        }

        // public async Task<IActionResult> SyncSeasonLineups()
        // {
        //     var season_Lineups_From_Api = await _sportRadarApiService.GetCompetitionRounds(SeasonId);
            
        //     // Assuming seasonInfo is not null and contains a list of seasons
        //     List<SeasonLineups> seasonLineups = new List<SeasonLineups>();
            
        //     foreach (var sR_Season_Lineup in season_Lineups_From_Api.Sr_Seasons)
        //     {
        //         var existingSeasonLineup = _rugbyDataDbContext.seasonLineups.FirstOrDefault(sL => sL.lineups == sR_Season_Lineup.);

        //         if (existingSeasonLineup == null)
        //         {
        //             SeasonLineups.Add(new SeasonLineups{
        //                 id = sR_Season_Lineup.id,
        //                 name = sR_Season_Lineup.name,
        //                 start_date = sR_Season_Lineup.start_date,
        //                 end_date = sR_Season_Lineup.end_date,
        //                 year = sR_Season_Lineup.year,
        //                 competition_id = sR_Season_Lineup.competition_id
        //             });
        //         }
        //     }
            
        //     // Add the entire collection to the DbContext
        //     _rugbyDataDbContext.seasons.AddRange(seasonsModel);

        //     // Save changes once, after adding all seasons
        //     await _rugbyDataDbContext.SaveChangesAsync();

        //     return Ok("Data synced successfully.");
        // }
        
        // public async Task<IActionResult> Syncplayers()
        // {
        //     return null;
        // }
    }
}