using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcRugby.Models;

namespace MvcRugby.ViewModels
{
    public class FixtureViewModel
    {
        public string CompetitionName {get; set;} // want to display the Competition details (Name)
        public int CompetitionId {get; set;}
        public string SrCompetitionId {get; set;}
        public List<Fixture> Fixtures {get; set;} // want to display the individual Fixture details (Date etc.)
        public List<TeamLineup>? TeamLineups {get; set;}
        public List<FixtureInfo> FixturesInfo {get; set;}
    }

    public class FixtureInfo
    {
        public int CompetitionId { get; set; } // From Competition entity (passed to fixture controller as parameter)
        public int? FixtureId { get; set; } // From Fixture entity
        public string? SrSportEventId {get; set;} // From Fixture entity
        public int? RoundNumber { get; set; } // From Fixture entity
        public DateTime? StartTime { get; set; } // From Fixture entity
        public string? Status { get; set; } // From Fixture entity
        public int? HomeScore { get; set; } // From Fixture entity
        public int? AwayScore { get; set; } // From Fixture entity
        public int? HomeTeamId { get; set; } // From TeamLineup & Team entity
        public string? HomeTeamName { get; set; } // from Team entity
        public int? AwayTeamId { get; set; } // From TeamLineup & Team entity
        public string? AwayTeamName { get; set; } // from Team entity
    }
}