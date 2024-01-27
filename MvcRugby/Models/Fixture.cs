using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Fixture
    {
        [Required]
        [Key]
        public int FixtureId { get; set; }
        public string? SrSportEventId {get; set;}
        public int RoundNumber { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        
        //PARENT ENTITY RELATIONSHIPS
        
        // Setup relationship with Competition entity
        [Required]
        [ForeignKey("CompetitionId")]
        public int CompetitionId { get; set; } // Foreign Key
        public Competition? Competition { get; set; } // Reference reverse navigation property
        

        // CHILD ENTITY RELATIONSHIPS
        
        // Setup relationship with Team Lineup model
        public List<TeamLineup>? TeamLineups { get; set; } // Reference navigation property

        //Relationship with Player Statistics model
        public List<PlayerStatistics>? PlayersStatistics { get; set; } // Reference navigation property
    }
}