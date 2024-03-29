// View model for the SportsRadar Index view
using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class CompetitionsViewModel
    {
        public List<SeasonViewModel>? Seasons { get; set; } //multiple Comps/Seasons, hence a list is required 
    }
    
    public class SeasonViewModel
    {
        public string? Id { get; set; } // Season Id
        public string? Name { get; set; } // Comp name and season
    }
}