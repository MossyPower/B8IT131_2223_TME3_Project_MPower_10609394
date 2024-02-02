using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyDataApi.Models
{
    public class PlayerStatistics
    {
        [Required]
        [Key]
        public int PlayerStatisticsId { get; set; }
        public int? Tries { get; set; }
        public int? TryAssists { get; set; } 
        public int? Conversions { get; set; } 
        public int? PenaltyGoals { get; set; } 
        public int? DropGoals { get; set; } 
        public int? MetersRun { get; set; } 
        public int? Carries { get; set; } 
        public int? Passes { get; set; }
        public int? Offloads { get; set; } 
        public int? CleanBreaks { get; set; } 
        public int? LineoutsWon { get; set; } 
        public int? LineoutsLost { get; set; }     
        public int? Tackles { get; set; } 
        public int? TacklesMissed { get; set; } 
        public int? ScrumsWon { get; set; } 
        public int? ScrumsLost { get; set; } 
        public int? TotalScrums { get; set; } 
        public int? TurnoversWon { get; set; } 
        public int? PenaltiesConceded { get; set; } 
        public int? YellowCards { get; set; } 
        public int? RedCards { get; set; } 
        
        // PARENT ENTITY RELATIONSHIPS
        
        // Setup relationship with Player entity
        [Required]
        [ForeignKey("Player")]
        public int PlayerId { get; set; } // Foreign Key
        public Player? Player { get; set; } // Reference reverse navigation property
        
        // Setup relationship with Fixture entity
        [Required]
        [ForeignKey("Fixture")]
        public int FixtureId { get; set; } // Foreign Key
        public Fixture? Fixture { get; set; } // Reference reverse navigation property
    }
}