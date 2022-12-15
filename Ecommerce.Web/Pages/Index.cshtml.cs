using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solid.Ecommerce.Application.Interfaces.Servcices;
using Solid.Ecommerce.Shared;
using Solid.Ecommerce.Application.ViewModels;

namespace Ecommerce.Web.Pages
{
    /*ViewModel*/
    public class IndexModel : PageModel
    {
       
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
  
        public IEnumerable<ProductViewModel> Products { get; private set;}

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