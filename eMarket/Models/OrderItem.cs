using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eMarket.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        [Required]
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
