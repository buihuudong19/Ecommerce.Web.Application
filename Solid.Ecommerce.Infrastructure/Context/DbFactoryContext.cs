namespace Solid.Ecommerce.Infrastructure.Context;
/// <summary>
/// Return instance (object) of DbContext (entity framework core) is SolidEcommerceDbContext
/// </summary>
public class DbFactoryContext : IDisposable
{
    /*fields*/
    private bool _disposed;//false
    private DbContext _dbContext;

    private Func<SolidEcommerceDbContext> _instanceFunc;
    /*properties*/
    public DbContext DbContext => _dbContext?? (_dbContext = _instanceFunc.Invoke());
    /*Constructor nay duoc goi thong qua service*/
    public DbFactoryContext(Func<SolidEcommerceDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public void Dispose()
    {
        if(!_disposed && _dbContext != null)
        {
            _disposed = true;
            _dbContext.Dispose();
        }
    }
}
