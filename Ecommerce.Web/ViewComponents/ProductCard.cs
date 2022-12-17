namespace Ecommerce.Web.ViewComponents;
[ViewComponent]
public class ProductCard:ViewComponent
{
    private ProductViewModel _productViewModel;

    public ProductCard()
    {
    }
    public IViewComponentResult Invoke(ProductViewModel productViewModel)
    {
        _productViewModel = productViewModel;
        return View(_productViewModel);
    }
}
