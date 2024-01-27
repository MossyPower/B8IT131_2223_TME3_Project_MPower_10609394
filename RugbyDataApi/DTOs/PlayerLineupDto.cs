namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class PlayerLineupDto
    {
        public int PlayerLineupId { get; set; }
        public string? SrPlayerId {get; set;}
        public int JerseyNumber { get; set; }
    }
}