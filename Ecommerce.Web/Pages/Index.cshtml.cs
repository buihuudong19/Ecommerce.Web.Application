using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.Application.Interfaces.Servcices;
using Solid.Ecommerce.Shared;

namespace Ecommerce.Web.Pages
{
    public class IndexModel : PageModel
    {
       
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
  
        public IEnumerable<Product> Products { get; private set;}

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;   
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAll();
        }
    }
}