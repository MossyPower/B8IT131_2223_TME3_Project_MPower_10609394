namespace RugbyDataApi.Models;

public class CompetitionRound
{
    public string? Round_Id { get; set; }
    public int? Round_Number { get; set; }
    public string? Status { get; set; } // E.g.: Ended / Live / 
    public DateOnly Start_Date { get; set; } 
    public DateOnly End_Date { get; set; } 

    public string? Competition_Id { get; set; }
    public Competition? Competition { get; set; }
    
    public string? CompetitionGame_Id { get; set; }
    public List<CompetitionGame>? CompetitionGame { get; set; }
}