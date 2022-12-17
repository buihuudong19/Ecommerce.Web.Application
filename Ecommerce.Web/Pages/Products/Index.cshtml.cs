using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Web.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    [ViewData]
    public string Title { get; set; }
    public IEnumerable<ProductViewModel> Products { get; set; } 

    public async Task  OnGetAsync(int? subCategoryId)
    {
        Title = subCategoryId.HasValue ? $"List products by {subCategoryId}" : $"List all products";
        Products = await _productService.GetAllProductBySubCategoryIdAsync(subCategoryId);
    }
   
}
