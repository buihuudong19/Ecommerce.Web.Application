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

    public async Task<IEnumerable<Product>> GetAll() 
        => await _unitOfWork.Repository<Product>().GetAllAsync();


    public async Task<Product> GetOne(int productId) => await _unitOfWork.Repository<Product>().FindAsync(productId);


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
