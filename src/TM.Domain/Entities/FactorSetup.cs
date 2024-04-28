namespace TM.Domain.Entities
{
    public class FactorSetup
    {
        public string FactorsID { get; set; }
        public string SetupsID { get; set; }

        public Factor Factor {  get; set; }
        public Setup Setup { get; set; }
    }
}
