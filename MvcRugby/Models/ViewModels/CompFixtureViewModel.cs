using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class CompetitionFixturesViewModel
    {
        public class Competition
        {
            public int CompetitionId { get; set; } 
            public string? Competition_Name { get; set; }          
            public List<Fixture>? Fixtures { get; set; }
        }

        public class Fixture
        {
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
        }
    }
}