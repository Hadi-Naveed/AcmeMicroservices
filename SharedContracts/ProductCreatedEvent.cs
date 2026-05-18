namespace SharedContracts
{
    public class ProductCreatedEvent
    {
        public  required string ProductId { get; set; }
        public required string CreatedByUserId { get; set; }
        public required string ProductName { get; set; }
    }
}
