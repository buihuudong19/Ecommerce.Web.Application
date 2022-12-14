
namespace Solid.Ecommerce.Application.ViewModels;
public class ProductViewModel:IMapFrom<Product>
{
    public ProductViewModel()
    {
        ProductProductPhotos = new List<ProductProductPhotoViewModel>();
    }

    public int ProductId { get; set; }
    
    public string ProductName { get; set; } = null!;
    public string ProductNumber { get; set; } = null!;
    public bool? MakeFlag { get; set; }
    public string? Color { get; set; }
    [Display(Name ="Cost")]
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string? ProductLine { get; set; }
    public int? ProductSubcategoryId { get; set; }
    public string? Description { get; set; }
    public int? StatusId { get; set; }
    public virtual ProductStatus? Status { get; set; }
    public string? PrimaryPhotoLargeFileName { get; set; }
    public decimal? DiscountPercent { get; set; }
    public virtual ICollection<ProductProductPhotoViewModel> ProductProductPhotos { get; set;}
    public virtual ProductSubcategoryViewModel? ProductSubcategory { get; set; }
    

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductViewModel>()
            .ForMember(dst => dst.ProductName, src => src.MapFrom(p => p.Name))
            .ForMember(dst => dst.PrimaryPhotoLargeFileName,
                src => src.MapFrom(
                    p => p.ProductProductPhotos
                    .Where(p => p.Primary)
                    .FirstOrDefault()
                    .ProductPhoto
                    .LargePhotoFileName
                    ));

    }
}
