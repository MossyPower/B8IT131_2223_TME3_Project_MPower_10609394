using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyDataApi.Models
{
    public class Club
    {
        //Club Attributes
        [Required]
        [Key]
        public int ClubId { get; set; }
        public string? SportRadar_Competitor_Id {get; set;}
        public string? Club_Name { get; set; } // E.g.: Munster
        
        //Setup relationship with Competition model/table
        [Required]
        [ForeignKey("CompetitionId")]
        public int CompetitionId { get; set; } //ForeignKey
        public virtual Competition? Competition { get; set; } //Reference navigation property
        
        // Reverse navigation property
        public List<Player>? Players { get; set; }
        // Reverse navigation property
        public List<Fixture>? Fixtures { get; set; }
    }
}