using Microsoft.AspNetCore.Mvc;
using InventoryService.Data;
using InventoryService.Models;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _db;

        public InventoryController(InventoryDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Inventory inventory)
        {
            _db.Inventories.Add(inventory);
            await _db.SaveChangesAsync();

            return Ok(inventory);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Inventories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _db.Inventories.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Inventory updated)
        {
            var item = _db.Inventories.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            item.ProductId = updated.ProductId;
            item.Stock = updated.Stock;

            await _db.SaveChangesAsync();

            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = _db.Inventories.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            _db.Inventories.Remove(item);
            await _db.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}