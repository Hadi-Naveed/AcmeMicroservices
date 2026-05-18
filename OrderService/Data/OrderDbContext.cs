using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
