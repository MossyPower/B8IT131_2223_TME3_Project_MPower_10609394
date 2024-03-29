using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyDataApi.Models
{
    public class PlayerLineup
    {
        [Required]
        [Key]
        public int PlayerLineupId { get; set; } // Autogenerated Id
        public string? SrPlayerId { get; set; }
        public int JerseyNumber { get; set; } 

        // PARENT ENTITY RELATIONSHIPS
        
        // Setup relationship with Player entity
        [Required]
        [ForeignKey("Player")]
        public int PlayerId { get; set; } // Foreign Key
        public Player? Player { get; set; } // Reference reverse navigation property
        
        // Setup relationship with Team Lineup entity
        [Required]
        [ForeignKey("TeamLineup")]
        public int TeamLineupId { get; set; } // Foreign Key
        public TeamLineup? TeamLineup { get; set; } // Reference reverse navigation property
    }
}