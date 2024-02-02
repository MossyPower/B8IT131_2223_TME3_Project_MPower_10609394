using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class CreateTeamLineupViewModel
    {
        public int? CompetitionId {get; set;} 
        public TeamLineup? TeamLineup {get; set;}
    }
}