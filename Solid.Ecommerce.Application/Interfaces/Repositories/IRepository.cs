namespace Solid.Ecommerce.Application.Interfaces.Repositories;
public interface IRepository<T>:
    IBaseReaderRepository<T>,
    IBaseWriterRepsitory<T>,
    IBaseRepo<T> where T : class
{

}
