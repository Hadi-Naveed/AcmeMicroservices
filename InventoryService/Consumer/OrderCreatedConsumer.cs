using InventoryService.Data;
using InventoryService.Models;
using MassTransit;
using SharedContracts;

namespace InventoryService.Consumer
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly InventoryDbContext _db;

        public OrderCreatedConsumer(InventoryDbContext db)
        {
            _db = db;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var msg = context.Message;

            var inventory = _db.Inventories
                .FirstOrDefault(x => x.ProductId == msg.ProductId);

            if (inventory == null || inventory.Stock < msg.Quantity)
            {
                await context.Publish(new OrderFailedEvent
                {
                    OrderId = msg.OrderId,
                    Reason = "Out of Stock"
                });
                Console.WriteLine("Publishing OrderFailedEvent");
                return;
            }

            if (inventory.Stock >= msg.Quantity)
            {
                inventory.Stock -= msg.Quantity;
                await _db.SaveChangesAsync();

                await context.Publish(new OrderConfirmedEvent
                {
                    OrderId = msg.OrderId
                });
            }

          
            

           

           
        }
    }
}
