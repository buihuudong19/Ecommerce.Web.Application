namespace Solid.Ecommerce.Application.Base;
public interface IBaseRepo<T> where T : class
{
    ///<summary>
    ///Return all Entities
    ///</summary>
    DbSet<T> Entities { get;} /*read-only*/
    IApplicationDBContext ApplicationDBContext { get; } //trung gian giup ta thao tac voi database
}
