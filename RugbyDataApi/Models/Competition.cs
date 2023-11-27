namespace RugbyDataApi.Models;

public class Competition
{
    public string? Competition_Id { get; set; }
    public string? Competition_Name { get; set; } // e.g.: United Rugby Championship
    public DateOnly Start_Date { get; set; } // E.g.: 21/10/2023
    public DateOnly End_Date { get; set; }
    public string? Season_ID { get; set; } 
    public Season? Season { get; set; } // E.g.: 2023/2024 
    public List<Club>? Clubs { get; set; } 
}