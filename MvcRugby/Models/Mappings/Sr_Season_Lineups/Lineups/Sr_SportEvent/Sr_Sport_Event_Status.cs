namespace MvcRugby.Mappings
{
    public class Sr_Sport_Event_Status
    {
        public string? Sr_Status {get; set;} // E.g: "closed"
        public string? Sr_Match_Status {get; set;} // E.g: "ended"
        public int? Sr_Home_Score {get; set;} // E.g: 36
        public int? Sr_Away_Score {get; set;} // E.g: 40
        public string? Sr_Winner_Id {get; set;} // E.g: "sr:competitor:4211"
        public List<Sr_SES_Period_Scores>? Sr_Period_Scores {get; set;}
    }
}