
namespace Solid.Ecommerce.Application.ViewModels;
public class ProductPhotoViewModel: IMapFrom<ProductPhoto>
{
    public int ProductPhotoId { get; set; }
    public string? ThumbnailPhotoFileName { get; set; }
    public string? LargePhotoFileName { get; set; }
    public virtual ICollection<ProductProductPhotoViewModel> ProductProductPhotos { get; } = new List<ProductProductPhotoViewModel>();
}
