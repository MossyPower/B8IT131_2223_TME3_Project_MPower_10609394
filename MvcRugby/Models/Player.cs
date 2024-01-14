using System.ComponentModel.DataAnnotations;

namespace MvcRugby.Models
{
    public class Player
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Nationality { get; set; } 
        public string? Position { get; set; } 
        public string? Jersey_Number { get; set; } 
        public string? Age { get; set; } 
        public string? Weight { get; set; } 
        
        // Relationship with child
        public List<PlayerMatchStatistics>? Statistics { get; set; } //Reference navigation property
        
        // Relationship with parent
        //public string? Club_Id { get; set; } //Foreign Key
        public Club? Club { get; set; } //Reference navigation property
    }
}