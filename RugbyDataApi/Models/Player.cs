using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
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
        
        //Reference navigation property - to Parent
        public Club? Club { get; set; }
        
        //Reference navigation property - to Child
        public List<PlayerFixtureStatistics>? PlayerFixtureStatistics { get; set; }
    }
}