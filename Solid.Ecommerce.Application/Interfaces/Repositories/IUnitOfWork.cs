
namespace Solid.Ecommerce.Application.Interfaces.Repositories;
public interface IUnitOfWork
{
    /*Connection to db*/
    IApplicationDBContext ApplicationDBContext { get; } //read-only property

    /// <summary>
    /// Get repository instance of an entity inside UnitOfWork scope
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IRepository<T> Repository<T>() where T : class;
    /// <summary>
    /// Saves changes to database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    Task BeginTransaction();
    /// <summary>
    /// Commits the current transaction (applied all command to database)
    /// </summary>
    /// <returns></returns>
    Task CommitTransaction();
    /// <summary>
    /// Rolls back the current transaction...
    /// </summary>
    /// <returns></returns>
    Task RollbackTransaction();
}
