using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class TeamLineup
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamLineupId { get; set; } // Autogenerated Id
        public string? Designation { get; set; } // e.g.: Home or Away
        // PARENT ENTITY RELATIONSHIPS

        // Setup relationship with Fixture
        [Required]
        [ForeignKey("Fixture")]
        public int FixtureId { get; set; } // ForeignKey
        public Fixture? Fixture { get; set; } // Reference reverse navigation property
        
        [Required]
        [ForeignKey("Team")]
        // Setup relationship with Team
        public int TeamId { get; set; } // ForeignKey
        public Team? Team { get; set; } // Reference reverse navigation property
        
        // CHILD ENTITY RELATIONSHIPS

        // Setup relationship with Player Lineup Entity
        public List<PlayerLineup>? PlayerLineups { get; set; } // Reference navigation property
    }
}