namespace RugbyDataApi.DTOs //DTOs = Data Model Objects
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string? SrPlayerId {get; set;}
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        public List<PlayerLineupDto>? PlayerLineups { get; set; }
        public List<PlayerStatisticsDto>? PlayersStatistics { get; set; }
    }
}