using MassTransit;
using OrderService.Data;
using SharedContracts;

namespace OrderService.Services
{
    public class OrderConfirmedConsumer : IConsumer<OrderConfirmedEvent>
    {
        private readonly OrderDbContext _db;

        public OrderConfirmedConsumer(OrderDbContext db)
        {
            _db = db;
        }

        public async Task Consume(ConsumeContext<OrderConfirmedEvent> context)
        {
            var order = _db.Orders
                .FirstOrDefault(x => x.Id == context.Message.OrderId);

            if (order != null)
            {
                order.Status = "Confirmed";
                await _db.SaveChangesAsync();
            }
        }
    }
}
