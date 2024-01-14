using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class CompetitionRound
    {
        public string? Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public int? Round_Number { get; set; }
        public string? Status { get; set; }
        public DateOnly Start_Date { get; set; } 
        public DateOnly End_Date { get; set; } 
        
        // Relationship with parent
        //public string? Competition_Id { get; set; } //Foreign Key
        public Competition? Competition { get; set; } //Reference navigation property
        
        // Relationship with child
        //public string? CompetitionGame_Id { get; set; } //Foreign Key
        public List<CompetitionGame>? CompetitionGame { get; set; } //Reference navigation property
    }
}