namespace Solid.Ecommerce.Services.Services;
public class ProductCategoryService : IProductCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductSubcategoryViewModel>> GetAllCategoryAsync()
    {
        return await _unitOfWork.Repository<ProductSubcategory>()
            .Entities
            .ProjectTo<ProductSubcategoryViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductSubcategoryViewModel>> GetAllCategoryAsync(Expression<Func<ProductSubcategoryViewModel, bool>> predicate)
    {
        return await _unitOfWork.Repository<ProductSubcategory>()
           .Entities
           .ProjectTo<ProductSubcategoryViewModel>(_mapper.ConfigurationProvider)
           .Where(predicate)
           .ToListAsync();
    }
}
