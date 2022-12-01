namespace Solid.Ecommerce.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    //Cache repository cua moi Entity, thi du: <Product,new Repository<Product>(db)>; 
    private Dictionary<string,object> Repositories { get; }

    private IDbContextTransaction _transaction;
    private IsolationLevel? _isolationLevel;


    public IApplicationDBContext ApplicationDBContext { get; private set; }

    public UnitOfWork(IApplicationDBContext applicationDBContext)
    {
        ApplicationDBContext = applicationDBContext;
        Repositories = new Dictionary<string, dynamic>();
    }

    public async Task BeginTrasaction()
    {
        await StartNewTransaction();
    }

    public async Task CommitTrasaction()
    {
        await ApplicationDBContext.DbContext.SaveChangesAsync();
        if (_transaction == null) return;
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    /*Return instance of Repository class */
    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        var typeName = type.Name;
        /*lock: neu nhu co da luong (multi-threading) thi cac luong se duoc cho nhau */
        lock (Repositories)
        {
            if (Repositories.ContainsKey(typeName))
            {
                return (IRepository<T>)Repositories[typeName];
            }
            var repository = new Repository<T>(ApplicationDBContext);
            Repositories.Add(typeName, repository);
            return repository;  
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await ApplicationDBContext.DbContext.SaveChangesAsync(cancellationToken);
    }


    private async Task StartNewTransaction()
    {
        if(_transaction == null)
        {
            _transaction = _isolationLevel.HasValue ?
                await ApplicationDBContext.DbContext.Database
                .BeginTransactionAsync(_isolationLevel.GetValueOrDefault()):
                await ApplicationDBContext.DbContext.Database.BeginTransactionAsync();
        }
    }

    public async Task RollbackTransaction()
    {
        if (_transaction is null) return;
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public void Dispose()
    {
        if (ApplicationDBContext is null) return;
        //close connection
        if (ApplicationDBContext.DbContext.Database.GetDbConnection().State == ConnectionState.Open)
        {
            ApplicationDBContext.DbContext.Database.GetDbConnection().Close();
        }
        ApplicationDBContext.DbContext.Dispose();
        ApplicationDBContext = null;

        GC.SuppressFinalize(this);
    }
}
