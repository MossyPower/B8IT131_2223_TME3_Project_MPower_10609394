using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class ComparisonViewModel
    {
        //What do we need?
        //  Page Headers:
        //      Competition Name [Competition => competitio_Name (pass comp id as param?)]
        //      Round Number [Fixture model => Round_Number (pass round number as param?)]
        //  Table Headers:
        //      Clubs [Can get from Fixture model]
        //  Table Body: [Player model]
        //      players (1 - 23)
        //      players (1 - 23) => FixtureStatistics

        [Required]
        public int CompetitionId { get; set; }
        public string Competition_Name { get; set; }
        public int Round_Number { get; set; }
        public List<Fixture>? Fixtures { get; set; }
        public List<Player>? Players { get; set; } // Figure out why we have both Players and Player models..!
        public List<FixtureStatistics>? FixtureStatistics { get; set;}
    }
}