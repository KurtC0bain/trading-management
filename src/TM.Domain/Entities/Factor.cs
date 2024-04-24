namespace TM.Domain.Entities
{
    public class Factor
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        //Navigation 
        public IEnumerable<Setup> Setups { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
    }
}
