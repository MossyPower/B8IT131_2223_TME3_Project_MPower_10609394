using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class Club
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? Competition_Name { get; set; } // e.g.: United Rugby Championship
        public string? Club_Name { get; set; } // E.g.: Munster
        public string? Country { get; set; } // E.g.: Ireland
    }
}