namespace MvcRugby.Mappings
{
    public class SEContext
    {
        public SECSport? sport {get; set;}
        public SECCategory? category {get; set;}
        public SECCompetition? competition {get; set;}
        public SECSeason? season {get; set;}
        public SECStage? stage {get; set;}
        public SECRound? round {get; set;}
        public SECGroups? groups {get; set;}
    }
}