using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eMarket.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть назву товару")]
        [Display(Name = "Назва товару")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Додайти опис товару")]
        [Display(Name = "Опис")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Вкажіть вартість товару")]
        [Display(Name = "Вартість")]
        public string? Price { get; set; }

        [Required(ErrorMessage = "Фото товару")]
        [Display(Name = "Додайте фото")]
        public byte[]? Photo { get; set; }
    }
}
