using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BigPicture.Data.Models;
using BigPicture.Data.Repositories;

namespace BigPicture.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductRepository _productRepository;

        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        public IndexModel(IProductRepository productRepository, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async void OnGet()
        {
            Products = await _productRepository.GetAll();
        }
    }
}