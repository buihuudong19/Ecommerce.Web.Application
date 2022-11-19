namespace Solid.Ecommerce.Application.Interfaces.Common;
/// <summary>
/// Interface support execute all operations (CRUD) relate to Database via Entity Framework Core
/// </summary>
public interface IApplicationDBContext
{
    DbContext DbContext { get; }  /*Entity Framework Core*/  
}
