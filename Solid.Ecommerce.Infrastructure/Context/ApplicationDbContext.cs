namespace Solid.Ecommerce.Infrastructure.Context;
public class ApplicationDbContext:IApplicationDBContext
{
    private DbFactoryContext _dbFactoryContext;
    public ApplicationDbContext(DbFactoryContext dbFactoryContext) => _dbFactoryContext = dbFactoryContext;

    public DbContext DbContext => _dbFactoryContext.DbContext;
}
