using System.ComponentModel.DataAnnotations;

namespace RugbyDataApi.Models
{
    public class Competition
    {
              
        [Required]
        public int Id { get; set; }
        public string? SportRadar_Id {get; set;}
        public string? Competition_Name { get; set; }
        public  DateTime? Start_Date { get; set; }
        public DateOnly? End_Date { get; set; }
        
        // Relationship with Parent
        //public string? Season_ID { get; set; } //Foreign Key 
        public Season? Season { get; set; } //Reference navigation property
        
        // Relationship with Child
        //public string? Club_Id { get; set; } //Foreign Key
        public Club? Clubs { get; set; } //Reference navigation property
    }
}