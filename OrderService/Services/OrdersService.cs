using MassTransit;
using OrderService.Data;
using SharedContracts;

namespace OrderService.Services
{
    public class OrderFailedConsumer : IConsumer<OrderFailedEvent>
    {
        private readonly OrderDbContext _db;

        public OrderFailedConsumer(OrderDbContext db)
        {
            _db = db;
        }

        public async Task Consume(ConsumeContext<OrderFailedEvent> context)
        {
            var order = _db.Orders.FirstOrDefault(x => x.Id == context.Message.OrderId);

            if (order != null)
            {
               
                order.Status = "Failed - Out of Stock";
                await _db.SaveChangesAsync();
                Console.WriteLine("Rollback triggered");
                Console.WriteLine($"ROLLBACK RECEIVED: {context.Message.OrderId}");
            }
        }
    }
}
