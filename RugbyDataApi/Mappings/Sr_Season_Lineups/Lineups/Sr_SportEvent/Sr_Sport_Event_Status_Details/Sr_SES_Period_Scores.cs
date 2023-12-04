namespace RugbyDataApi.Mappings
{
    public class Sr_SES_Period_Scores
    {
        public int? Sr_Home_Score {get; set;} // E.g: 26
        public int? Sr_Away_Score {get; set;} // E.g: 21
        public string? Sr_Type {get; set;} // E.g: "regular_period"
        public int? Sr_Number {get; set;} // E.g: 1
    }
}