namespace RugbyDataApi.Models;

public class Player
{
    public string? Player_Id { get; set; }
    public string? First_Name { get; set; }
    public string? Last_Name { get; set; }
    public string? Nationality { get; set; } 
    public string? Position { get; set; } 
    public string? Jersey_Number { get; set; } 
    public string? Age { get; set; } 
    public string? Weight { get; set; } 
    public List<PlayerMatchStatistics>? Statistics { get; set; }
    public string? Club_Id { get; set; }
    public Club? Club { get; set; }
}