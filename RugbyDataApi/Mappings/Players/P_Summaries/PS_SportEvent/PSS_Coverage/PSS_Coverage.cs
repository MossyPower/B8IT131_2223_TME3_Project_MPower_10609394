// Naming Convention Meaning: 
// PSSC = Player | Summaries | Sport Event | Coverage

namespace RugbyDataApi.Mappings
{
    public class PSS_Coverage
    {
        public bool? live { get; set; }
        public List<PSSC_Properties>? properties { get; set; }
    }
}