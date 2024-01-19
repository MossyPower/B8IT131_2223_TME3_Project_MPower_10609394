using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Club
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; } // E.g.: Munster
        
        //Reference navigation property - to parent
        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }
        
        //Reference navigation property - to child
        public List<Player>? Players { get; set; } 
    }
}