namespace Solid.Ecommerce.Services.Services;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

    public Task Delete(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _unitOfWork.Repository<Product>().GetAllAsync();
    }

    public Task<Product> GetOne(int productId)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }
}
