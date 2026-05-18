using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.DTOs;
using OrderService.Models;
using SharedContracts;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _db;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(OrderDbContext db, IPublishEndpoint publishEndpoint)
        {
            _db = db;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto )
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
               ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Status = "Pending"
                
            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

         
            await _publishEndpoint.Publish(new OrderCreatedEvent
            {
                OrderId = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                
            });

            return Ok(order);
        }
    }
}
