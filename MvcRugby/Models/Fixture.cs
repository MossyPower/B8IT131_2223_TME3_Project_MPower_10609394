using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Fixture //i.e. competition game / match (e.g.: Munster Vs. Leinster)
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public int Round_Number { get; set; }
        public string Fixture_Date { get; set; }
        public string? Start_Time { get; set; }
        public string? Status { get; set; }
        public string? Home_Team { get; set; }
        public string? Away_Team { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }
        
        //Reference navigation property - to parent
        [ForeignKey("CompetitionId")]
        public Competition Competition { get; set; }

        //Reference navigation property - to child
        public List<Club>? Clubs { get; set; }
        public List<FixtureStatistics>? FixtureStatistics { get; set; }
    }
}