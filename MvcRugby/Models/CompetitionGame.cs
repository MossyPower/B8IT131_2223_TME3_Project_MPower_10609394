using System.ComponentModel.DataAnnotations;

namespace MvcRugby.Models
{
    public class CompetitionGame
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? Venue { get; set; }
        public string? Home_Score { get; set; }
        public int? Away_Score { get; set; } 
        
        // Relationship with Parent
        //public string? Round_Id { get; set; } //Foreign Key  
        public CompetitionRound? CompetitionRound { get; set; } //Reference navigation property

        // Relationship with Parent
        //public string? Competition_Id { get; set; } //Foreign Key
        public Competition? Competition { get; set; } //Reference navigation property
    }
}