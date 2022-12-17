namespace Solid.Ecommerce.Application.Interfaces.Services;
public interface IProductCategoryService
{
    Task<IEnumerable<ProductSubcategoryViewModel>> GetAllCategoryAsync();
    Task<IEnumerable<ProductSubcategoryViewModel>> GetAllCategoryAsync(Expression<Func<ProductSubcategoryViewModel, bool>> predicate);
}
