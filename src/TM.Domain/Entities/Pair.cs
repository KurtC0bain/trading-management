namespace TM.Domain.Entities
{
    public class Pair
    {
        public string ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        //Navigation
        public IEnumerable<Trade> Trades { get; set; }
    }
}
