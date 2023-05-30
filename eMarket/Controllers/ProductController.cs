using eMarket.Data.Services;
using eMarket.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async  Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(ProductViewModel vm)
        {
            await _service.CreateAsync(vm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async  Task<IActionResult> Update(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,ProductViewModel vm)
        {
            await _service.UpdateAsync(id,vm);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
