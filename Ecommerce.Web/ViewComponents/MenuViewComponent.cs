namespace Ecommerce.Web.ViewComponents;
public class MenuViewComponent: ViewComponent
{
    private readonly IProductCategoryService _productCategoryService;

    public MenuViewComponent(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var productSubCategory = (await _productCategoryService.GetAllCategoryAsync(psc => psc.ProductCategoryId == 1)).ToList();

        if (!productSubCategory.Any())
        {
            return new ContentViewComponentResult("Unable to get the Productsubcategory..");
        }
        return View("MenuView",productSubCategory);

    }

}
