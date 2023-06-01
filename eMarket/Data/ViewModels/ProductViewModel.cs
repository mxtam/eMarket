﻿
namespace eMarket.Data.ViewModels
{
    public class ProductViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
