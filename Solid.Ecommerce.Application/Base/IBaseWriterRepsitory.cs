namespace Solid.Ecommerce.Application.Base;
public interface IBaseWriterRepsitory<T> :IBaseRepo<T> where T : class
{
    Task InsertAsync(T entity, bool saveChange = true);
    Task InsertRangeAsync(IEnumerable<T> entities, bool saveChange = true);
    Task UpdateAsync(T entity, bool saveChange = true);
    Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChange = true);
    Task DeleteAsync(int id, bool saveChange = true);//Overloading
    Task DeleteAsync(T entity, bool saveChange = true); 
    Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChange = true); 
}
