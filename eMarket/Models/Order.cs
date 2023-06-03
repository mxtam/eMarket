using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMarket.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? Email { get; set; } 

        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }


        public List<OrderItem>? OrderItems { get; set; }
    }
}
