using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class FixtureLineupViewModel
    {        
        public Competition Competition {get; set;} // want to display the Competition details (Name)
        public Fixture Fixture {get; set;} // want to display the individual Fixture details (Date etc.)
        
        public List<TeamLineup> TeamLineup {get; set;}
        public List<PlayerLineup> PlayerLineup {get; set;}
        //public List<Team> Teams {get; set;}
        //public List<Player> Players {get; set;}


        public TeamLineup HomeTeamLineup  {get; set;}
        public TeamLineup AwayTeamLineup  {get; set;}


        public List<PlayerLineup> HomePlayerLineups  {get; set;}
        public List<PlayerLineup> AwayPlayerLineups  {get; set;}


        public Team HomeTeam {get; set;}
        public Team AwayTeam {get; set;}


        public List<Player> HomePlayers {get; set;}
        public List<Player> AwayPlayers {get; set;}
    }
}