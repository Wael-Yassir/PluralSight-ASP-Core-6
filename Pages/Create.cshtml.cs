using BigPicture.Data.Models;
using BigPicture.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BigPicture.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product NewProduct { get; set; } = new();

        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productRepository.Add(NewProduct);
            return RedirectToPage("Index");
        }
    }
}
