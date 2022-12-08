using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;
namespace Solid.Ecommerce.Infrastructure.Extensions;
public static class RepositoryExtensions
{
    /// <summary>
    /// Filter the data with the query...
    /// </summary>
    public static IQueryable<T> Where<T>(
        this IRepository<T> repository, Expression<Func<T,bool>> predicate
        ) where T : class
    => repository.Entities.Where(predicate);
    /// <summary>
    /// Get list of data for the tenant...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="repository"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static async Task<List<T>> ToListAsync<T>(this IRepository<T> repository,
        Expression<Func<T,bool>> predicate) where T : class
    => await repository.Where(predicate).ToListAsync();
    /// <summary>
    /// Order by data for the tenant...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="repository"></param>
    /// <param name="keySelector"></param>
    /// <returns></returns>
    public static IOrderedQueryable<T> OrderBy<T, TKey>(this IRepository<T> repository, Expression<Func<T, TKey>> keySelector) where T: class
    => repository.OrderBy(keySelector);

    /// <summary>
    /// Filter the data for the tenant and include the navigation property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="repository"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static IIncludableQueryable<T, TProperty> Include<T, TProperty>(this IRepository<T> repository,Expression<Func<T, TProperty>> path) where T : class
    {
        return repository.Entities.Include(path);
    }



}
