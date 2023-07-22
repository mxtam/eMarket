using System.ComponentModel.DataAnnotations;

namespace eMarket.Models
{
    public class ShopingCartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }
        public int Amount { get; set; }


        public string ShopingCartId { get; set; }
    }
}
