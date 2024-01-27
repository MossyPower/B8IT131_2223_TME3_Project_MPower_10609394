using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class CompetitionFixturesViewModel
    {
        
        public int CompetitionId { get; set; } 
        public string? CompetitionName { get; set; } 
        List<Fixture>? Fixtures { get; set; }

        public class Fixture
        {
            public int FixtureId { get; set; }
            public string? SportRadarId {get; set;}
            public int RoundNumber { get; set; }
            public string FixtureDate { get; set; }
            public string? StartTime { get; set; }
            public string? Status { get; set; }
            public string? HomeTeam { get; set; }
            public string? AwayTeam { get; set; }
            public int? HomeScore { get; set; }
            public int? AwayScore { get; set; }
        }
    }
}