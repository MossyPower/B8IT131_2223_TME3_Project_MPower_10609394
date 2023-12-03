// Naming Convention Meaning: 
// PSSS = Player | Summaries | Sport Event | Sport Event Conditions
namespace RugbyDataApi.Models
{
    public class PSS_SportEventContext
    {
        public PSSS_Sport? sport { get; set; }
        public PSSS_Category? category { get; set; }
        public PSSS_Competition? competition { get; set; }
        public PSSS_Season? season { get; set; }
        public PSSS_Stage? stage { get; set; }
        public PSSS_Round? round { get; set; }
        public List<PSSS_Groups>? groups { get; set; }
    }
}