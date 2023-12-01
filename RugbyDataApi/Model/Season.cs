using Microsoft.EntityFrameworkCore;

namespace RugbyDataApi.Models
{
    public class Season
    {
        public string? SeasonId { get; set; }
        public string? Year { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate{ get; set; }
        //public string? CompetitionId { get; set; }
        //public List<Competition>? Competitions { get; set; }
    }
}