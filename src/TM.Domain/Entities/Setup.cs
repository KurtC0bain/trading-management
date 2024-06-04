namespace TM.Domain.Entities
{
    public class Setup
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation
        public ICollection<Factor> Factors { get; set; }
        public IEnumerable<Trade> Trades { get; set; }
    }
}
