
namespace Solid.Ecommerce.Application.ViewModels;
public class ProductCategoryViewModel:IMapFrom<ProductCategory>
{
    public int ProductCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<ProductSubcategoryViewModel> ProductSubcategories { get; } = new List<ProductSubcategoryViewModel>();

}
