namespace Solid.Ecommerce.Application.ViewModels;
public class ProductProductPhotoViewModel: IMapFrom<ProductProductPhoto>
{
    public int ProductId { get; set; }
    public int ProductPhotoId { get; set; }
    public bool Primary { get; set; }
    public virtual ProductViewModel Product { get; set; } = null!;
    public virtual ProductPhotoViewModel ProductPhoto { get; set; } = null!;

}
