using System.ComponentModel.DataAnnotations;

namespace MvcRugby.Models
{
    public class Fixture //i.e. competition game / match (e.g.: Munster Vs. Leinster)
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? Round_Number { get; set; }
        public string? Start_Date { get; set; }
        public string? End_Date { get; set; }
        public string? Status { get; set; }
        public int? Home_Score { get; set; }
        public int? Away_Score { get; set; }
        
        //Reference navigation property - to parent
        public Competition? Competition { get; set; }
        
        //Reference navigation property - to child
        public List<Club>? Clubs { get; set; }
        public List<FixtureStatistics>? fixtureStatistics { get; set; }
    }
}