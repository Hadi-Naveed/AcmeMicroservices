using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Product
    {
        [Key]
        [MaxLength(10)]
        public string? ID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Mdt { get; set; }
        public string? CreatedByUserId { get; set; }  
        public string? CreatedByUserName { get; set; }
    }
}
