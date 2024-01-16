using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class Club
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; } // E.g.: Munster
        public string? Qualifier { get; set; }
        
        //Reference navigation property - to parent
        public Competition? competition { get; set; }
        
        //Reference navigation property - to child
        public List<Player>? Players { get; set; } 
    }
}