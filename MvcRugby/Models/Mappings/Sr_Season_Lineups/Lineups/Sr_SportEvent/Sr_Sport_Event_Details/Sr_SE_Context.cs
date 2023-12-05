namespace MvcRugby.Mappings
{
    public class Sr_SE_Context
    {
        public Sr_SEC_Sport? Sr_Sport {get; set;}
        public Sr_SEC_Category? Sr_Category {get; set;}
        public Sr_SEC_Competition? Sr_Competition {get; set;}
        public Sr_SEC_Season? Sr_Season {get; set;}
        public Sr_SEC_Stage? Sr_Stage {get; set;}
        public Sr_SEC_Round? Sr_Round {get; set;}
        public List<Sr_SEC_Groups>? Sr_Groups {get; set;}
    }
}