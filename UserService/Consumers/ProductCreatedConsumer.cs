using MassTransit;
using Microsoft.AspNetCore.Identity;
using SharedContracts;
using UserService.Data;
using UserService.Models;

namespace UserService.Consumers
{
    public class ProductCreatedConsumer : IConsumer<ProductCreatedEvent>
    {
        private readonly UserDbContext _db;
        public ProductCreatedConsumer(UserDbContext db)
        {
            _db = db;
        }
        public async Task Consume(ConsumeContext<ProductCreatedEvent> context)

        {
            var message = context.Message;
            var activity = new UserActivity
            {
                UserId = message.CreatedByUserId,
                Action = $"Product Created:{message.ProductName}"
            };
            _db.UserActivities.Add(activity);
           await _db.SaveChangesAsync();
          
        }
    }

}

