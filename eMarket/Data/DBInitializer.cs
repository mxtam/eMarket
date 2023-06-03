using eMarket.Models;

namespace eMarket.Data
{
    public class DBInitializer
    {
        
        private readonly ApplicationDbContext _context;
        public DBInitializer(ApplicationDbContext context) 
        {
            _context= context;
        }

        public void Seed() 
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                _context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "I don't care",
                            Description = "В'язаний світер з аніме принтом, для чоловіків та жінок",
                            Price = 1499,
                            Photo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\idc.jpg"))
                        },
                        new Product()
                        {
                            Name = "Cross",
                            Description = "Чоловічі штани в готичному стилі.",
                            Price = 1000,
                            Photo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\cross.jpg"))
                        },
                        new Product()
                        {
                            Name = "Ghost",
                            Description = "Чоловічі джогери в стилі Techwear",
                            Price = 1000,
                            Photo = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\ghost.jpg"))
                        },
                    });

                _context.SaveChanges();
            }
        }
    }
}
