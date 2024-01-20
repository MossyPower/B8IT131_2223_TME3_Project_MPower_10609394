using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Player
    {
        //Player Attributes
        [Required]
        public int PlayerId { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Nationality { get; set; } 
        public string? Position { get; set; } 
        public string? Jersey_Number { get; set; } 
        public string? Age { get; set; } 
        public string? Weight { get; set; } 
        
        //Setup relationship with Club model/table
        [ForeignKey("ClubId")]
        public int ClubId { get; set; } //Foreign Key
        public Club Club { get; set; } //Reference navigation property
        
        //Relationship with FixtureStatistics
        public List<FixtureStatistics>? FixtureStatistics { get; set; } //Reference navigation property
    }
}