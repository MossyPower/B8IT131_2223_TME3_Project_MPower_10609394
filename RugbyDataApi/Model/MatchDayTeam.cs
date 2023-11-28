using System.ComponentModel.DataAnnotations;
namespace RugbyDataApi.Models;

public class MatchDayTeam
{
    public string? Team_Id { get; set; }    
    public List<Club>? Clubs { get; set; }
    public List<Player>? Players { get; set; }
    public string? Game_Id { get; set; }
    public CompetitionGame? CompetitionGame { get; set; }
}