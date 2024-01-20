using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Fixture //i.e. competition game / match (e.g.: Munster Vs. Leinster)
    {
        //Fixture Attributes 
        [Required]
        public int FixtureId { get; set; }
        public string? SportRadar_Id {get; set;}
        public int Round_Number { get; set; }
        public string Fixture_Date { get; set; }
        public string? Start_Time { get; set; }
        public string? Status { get; set; }
        public string? Home_Team { get; set; }
        public string? Away_Team { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }
        
        //Setup relationship with Competition model/table
        [ForeignKey("CompetitionId")]
        public int CompetitionId { get; set; } //Foreign Key
        public Competition Competition { get; set; } //Reference navigation property

        //Relationship with Club model
        public List<Club>? Clubs { get; set; } //Reference navigation property
        //Relationship with FixtureStatistic model
        public List<FixtureStatistics>? FixtureStatistics { get; set; } //Reference navigation property
    }
}