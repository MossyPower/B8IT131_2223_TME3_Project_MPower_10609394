using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Competition
    {  
        [Required]
        [Key]
        public int CompetitionId { get; set; } 
        public string? SrCompetitionId {get; set;} //Sport Radar API Id, e.g: sr:competition:419 (for URC 23/24)(Sr_Season_Id: sr:season:106497) 
        public string? CompetitionName { get; set; } //Competition Name, e.g.: European Champions Cup
        public DateTime? StartDate { get; set; } //Competition Start Date, e.g.: 08.12.2023
        public DateTime? EndDate { get; set; } //Competition End Date, e.g: 25.05.2024
        public string? Year { get; set; } //Competition Year, e.g.: 23/24
        
        // CHILD ENTITY RELATIONSHIPS
        
        // Setup relationship with Fixture entity
        public List<Fixture>? Fixtures { get; set; } = new List<Fixture>(); // Reference navigation property
    }
}