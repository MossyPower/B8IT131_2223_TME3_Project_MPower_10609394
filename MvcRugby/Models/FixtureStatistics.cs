using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class FixtureStatistics
    {
        //FixtureStatistics Attributes
        [Required]
        public int FixtureStatisticsId { get; set; }
        public string? SportRadar_Id {get; set;}
        public int? Tries { get; set; }
        public int? Try_Assists { get; set; } 
        public int? Conversions { get; set; } 
        public int? Penalty_Goals { get; set; } 
        public int? Drop_Goals { get; set; } 
        public int? Ball_Possessition { get; set; }
        public int? Meters_Run { get; set; } 
        public int? Carries { get; set; } 
        public int? Passes { get; set; }
        public int? Offloads { get; set; } 
        public int? Clean_Breaks { get; set; } 
        public int? Lineouts_Won { get; set; } 
        public int? Lineouts_Lost { get; set; }     
        public int? Tackles { get; set; } 
        public int? Tackles_Missed { get; set; } 
        public int? Scrums_Won { get; set; } 
        public int? Scrums_Lost { get; set; } 
        public int? Total_Scrums { get; set; } 
        public int? Turnovers_Won { get; set; } 
        public int? Penalties_Conceded { get; set; } 
        public int? Yellow_Cards { get; set; } 
        public int? Red_Cards { get; set; } 
        
        //Setup relationship with Player model/table
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; } //Foreign Key
        public Player Player { get; set; } //Reference navigation property
        
        //Setup relationship with Fixture model/table
        [ForeignKey("FixtureId")]
        public int FixtureId { get; set; } //Foreign Key
        public Fixture Fixture { get; set; } //Reference navigation property

    }
}