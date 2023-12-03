namespace RugbyDataApi.Models
{    
    public class SECoverage
    {
        public bool? live {get; set;} // E.g: true
        public List<SECProperties>? properties {get; set;}

    }
}