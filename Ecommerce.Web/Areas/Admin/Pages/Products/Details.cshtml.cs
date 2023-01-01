using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Web.Areas.Admin.Pages.Products;

public class DetailsModel : BasePageModel<Product, DetailsModel>
{
	public DetailsModel(IProductService productService) : base(productService, "Details") { }

	[BindProperty]
	public ProductViewModel Product { get; set; } = default!;
	public async Task OnGetAsync(int? id)
	{
		await GetOneAsync(id);
		//Map tu Entity sang ProductViewModel
		Product = new ProductViewModel
		{
			ProductId = Entity.ProductId,
			ProductName = Entity.Name,
			ProductNumber = Entity.ProductNumber,
			Description = Entity.Description,
			PrimaryPhotoLargeFileName = Entity.ProductProductPhotos?
			.FirstOrDefault()?
			.ProductPhoto
			.LargePhotoFileName,
			ListPrice = Entity.ListPrice,
			StandardCost = Entity.StandardCost
		};
	}
}

