using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyDataApi.Models
{
    public class Player
    {
        //Player Attributes
        [Required]
        [Key]
        public int PlayerId { get; set; }
        public string? SrPlayerId {get; set;} //e.g: "sr:player:459344"
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? JerseyNumber { get; set; }
        
        // PARENT ENTITY RELATIONSHIPS

        // Setup relationship with Team entity
        [Required]
        [ForeignKey("TeamId")]
        public int TeamId { get; set; } // Foreign Key (Zero or One relationship, allow null / not required)
        public Team? Team { get; set; } // Reference reverse navigation property
        
        // Setup relationship with Team Lineup entity
        [ForeignKey("TeamLineupId")]
        public int? TeamLineupId { get; set; } // Foreign Key (Zero or One relationship, allow null / not required)
        public TeamLineup? TeamLineup { get; set; } // Reference reverse navigation property
        
        // CHILD ENTITY RELATIONSHIPS
        // Setup relationship with Player Statistics entity
        public List<PlayerStatistics>? PlayersStatistics { get; set; } // Reference navigation property
    }
}