using System.ComponentModel.DataAnnotations;
namespace RugbyDataApi.Models
{
    public class Season
    {
        public string? Id { get; set; }
        public string? Year { get; set; } // e.g.: 2023 / 2024
        public DateOnly Start_Date { get; set; } 
        public DateOnly End_Date { get; set; } 
        public string? Competition_Id { get; set; } 
        public List<Competition>? Competition { get; set; } 
    }
}