namespace MvcRugby.Mappings
{
    public class RdAPI_Player
    {
        public int PlayerId { get; set; }
        public string? SrPlayerId {get; set;}
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public List<RdAPI_PlayerLineup>? PlayerLineups { get; set; }
        public List<RdAPI_PlayerStatistics>? PlayersStatistics { get; set; }
    }
}