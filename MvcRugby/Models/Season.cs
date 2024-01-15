using System.ComponentModel.DataAnnotations;

namespace MvcRugby.Models
{
    public class Season
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;} // "sr:season:106497"  **use source ID system
        public string? Year { get; set; } // "23/24"
        public DateOnly? Start_Date { get; set; } // 2023-10-21  **Need to convert string to DateTime from incoming JSON data
        public DateOnly? End_Date { get; set; } // 2023-10-21  **Need to convert string to DateTime from incoming JSON data
        public string? Competition_Name { get; set; } // May not be available
    }
}