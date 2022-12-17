using AutoMapper.QueryableExtensions;
namespace Solid.Ecommerce.Services.Services;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Add(Product product)
    {
        
        try
        {
            
            await _unitOfWork.BeginTrasaction();
            await _unitOfWork.Repository<Product>().InsertAsync(product);
            await _unitOfWork.CommitTrasaction();

        }catch (Exception ex)
        {
            await _unitOfWork.RollbackTransaction();
            throw ex;
        }
    }

    public async Task Delete(int productId)
    {
        try
        {
            await _unitOfWork.BeginTrasaction();
            /*Lay repo cua Product*/
            var productRepo = _unitOfWork.Repository<Product>();
            var pro = await productRepo.FindAsync(productId);
            
            if (pro == null) throw new KeyNotFoundException();
            await productRepo.DeleteAsync(pro);
            await _unitOfWork.CommitTrasaction();

        }catch (Exception ex)
        {
            await _unitOfWork.RollbackTransaction();
            throw;
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetAll()
    {
        // => await _unitOfWork.Repository<Product>().GetAllAsync();
        return await _unitOfWork.Repository<Product>()
            .Entities
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductBySubCategoryIdAsync(int? subCategoryId)
    {
        var products = await _unitOfWork.Repository<Product>()
            .Entities
            .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
            .Where(pvm => subCategoryId.HasValue ? pvm.ProductSubcategory.ProductSubcategoryId == subCategoryId : pvm.ProductSubcategory.ProductCategoryId == 1)
            .ToListAsync();

        return products;
    }

    public async Task<ProductViewModel> GetOne(int productId)
    {
        //=> await _unitOfWork.Repository<Product>().FindAsync(productId);
        var product= await _unitOfWork.Repository<Product>().FindAsync(productId);
        return _mapper.Map<ProductViewModel>(product);
    }


    public async Task Update(Product product)
    {
       

        try
        {
            await _unitOfWork.BeginTrasaction();
            /*Lay instance cua Repository*/
            var productRepo = _unitOfWork.Repository<Product>();
            
            /*get a product */
            var pro = await productRepo.FindAsync(product.ProductId);
            if(pro == null) throw new KeyNotFoundException();
            
            pro.Name = product.Name;
            pro.Description = product.Description;

            await _unitOfWork.CommitTrasaction();
        }catch (Exception ex)
        {

        }
    }
}
