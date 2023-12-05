using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class Season
    {
        public string? Id { get; set; }
        public string? Year { get; set; } // e.g.: 2023 / 2024
        public DateTime? Start_Date { get; set; } 
        public DateTime? End_Date { get; set; } 
        public string? Competition_Id { get; set; } 
        public string? Competition_Name { get; set; } 
    }
}