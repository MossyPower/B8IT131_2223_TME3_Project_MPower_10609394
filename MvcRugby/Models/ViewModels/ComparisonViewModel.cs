namespace MvcRugby.Models
{
    // Combined ViewModel for (1) Competition, (2) Players, and (3) Fixture Statistics
    public class ComparisonViewModel
    {
        public string Competition { get; set;} 
        public int Round_Number { get; set;} 
        public List<Player> Players { get; set;}
        public IEnumerable<FixtureStatistics> FixtureStatistics { get; set;}
    }


}