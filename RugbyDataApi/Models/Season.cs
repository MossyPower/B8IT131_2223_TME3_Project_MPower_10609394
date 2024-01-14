using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class Season
    {
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;} // "sr:season:106497"  **use source ID system
        public string? Year { get; set; } // "23/24"
        public DateTime? Start_Date { get; set; } // 2023-10-21  **Need to convert string to DateTime from incoming JSON data
        public DateTime? End_Date { get; set; } // 2023-10-21  **Need to convert string to DateTime from incoming JSON data
        public string? Competition_Name { get; set; } // May not be available
    }
}