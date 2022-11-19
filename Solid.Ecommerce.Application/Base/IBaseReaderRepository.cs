namespace Solid.Ecommerce.Application.Base;
public interface IBaseReaderRepository<T>:IBaseRepo<T> where T : class
{
    ///<summary>
    /// Get all items of an entity by asynchronous method
    ///</summary>
    Task<IList<T>> GetAllAsync();
    ///<summary>
    /// Find one item of an entity synchronous method
    ///</summary>
    /// <param> name="keyValues" </param>
    /// <returns>T</returns>
    T Find(params object[] keyValues);
    ///<summary>
    /// Find one item of an entity asynchronous method
    ///</summary>
    /// <param> name="keyValues" </param>
    /// <returns>T</returns>
    Task<T> FindAsync(params object[] keyValues);
    

}

