namespace TM.Domain.Entities
{
    public class Setup
    {
        public Guid ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation
        public required IEnumerable<Factor> Factors { get; set; }
    }
}
