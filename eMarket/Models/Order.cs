using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMarket.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть ім'я отримувача")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Введіть прізвище отримувача")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введіть номер телефону отримувача")]
        [Display(Name = "Номер телефону")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Невірний формат")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введіть населений пункт")]
        [Display(Name = "Населений пункт")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Введіть відділення нової пошти")]
        [Display(Name = "Відділення нової пошти")]
        public string PostOffice { get; set; }



        public string? Email { get; set; }

        public string? UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }

        [Required]
        public List<OrderItem>? OrderItems { get; set; }
    }
}
