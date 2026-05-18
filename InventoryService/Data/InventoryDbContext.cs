using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
