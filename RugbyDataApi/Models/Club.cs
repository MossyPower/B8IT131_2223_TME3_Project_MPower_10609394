using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyDataApi.Models
{
    public class Club
    {
        //Club Attributes
        [Required]
        public int ClubId { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; } // E.g.: Munster
        
        //Setup relationship with Competition model/table
        [ForeignKey("CompetitionId")]
        public int CompetitionId { get; set; } //ForeignKey
        public Competition Competition { get; set; } //Reference navigation property
        
        //Relationship with Player model/table
        public List<Player>? Players { get; set; } //Reference navigation property
    }
}