
namespace Solid.Ecommerce.Application.ViewModels;
public class ProductSubcategoryViewModel:IMapFrom<ProductSubcategory>
{
    public int ProductSubcategoryId { get; set; }
    public int ProductCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public virtual ProductCategoryViewModel ProductCategory { get; set; } = null!;
    public virtual ICollection<ProductViewModel> Products { get; } = new List<ProductViewModel>();

}
