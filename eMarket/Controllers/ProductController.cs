using Microsoft.AspNetCore.Mvc;

namespace eMarket.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
