using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRugby.Models
{
    public class Competition
    {   
        [Required]
        public int Id { get; set; } 
        public string? SportRadar_Competition_Id {get; set;} //Sport Radar API Id, e.g: 
        public string? Competition_Name { get; set; } //Competition Name, e.g.: European Champions Cup
        public  string? Year { get; set; } //Competition Year, e.g.: 23/24
        public  string? Start_Date { get; set; } //Competition Start Date, e.g.: 08.12.2023
        public string? End_Date { get; set; } //Competition End Date, e.g: 25.05.2024
        
        //Reference navigation property - to child
        public List<Fixture>? Fixtures { get; set; }
    }
}