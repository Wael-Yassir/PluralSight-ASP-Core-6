using BigPicture.Data.Models;
using BigPicture.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigPicture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _productRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product newProduct)
        {
            if (!ModelState.IsValid) 
                return View();

            await _productRepository.Add(newProduct);
            return RedirectToAction("Index");
        }
    }
}
