using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class MatchDayTeam
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}    
        
        // Relationship with 
        public List<Club>? Clubs { get; set; } //Reference navigation property
        
        // Relationship with child
        public List<Player>? Players { get; set; } //Reference navigation property
        
        // Relationship with parent
        //public string? Game_Id { get; set; } //Foreign Key
        public CompetitionGame? CompetitionGame { get; set; } //Reference navigation property
    }
}