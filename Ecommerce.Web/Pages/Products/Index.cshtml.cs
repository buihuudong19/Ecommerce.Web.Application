using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ecommerce.Web.Utils;

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
    //public IEnumerable<ProductViewModel> Products { get; set; } 
    public PaginatedList<ProductViewModel> Products { get; set; }   
    public int? SubCategoryId { get; set; }

    public async Task  OnGetAsync(int? subCategoryId,int? pageIndex)
    {
        SubCategoryId = subCategoryId.HasValue ? subCategoryId.Value : null;
        Title = subCategoryId.HasValue ? $"List products by {subCategoryId}" : $"List all products";
        //Products = await _productService.GetAllProductBySubCategoryIdAsync(subCategoryId);
        var products = (await _productService.GetAllProductBySubCategoryIdAsync(subCategoryId)).AsQueryable();

        Products = PaginatedList<ProductViewModel>.Create(products, pageIndex ?? 1);

    }
   
}
