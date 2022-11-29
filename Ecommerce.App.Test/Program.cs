using Solid.Ecommerce.Infrastructure.Repositories;
using Solid.Ecommerce.Application.Interfaces.Repositories;
using Solid.Ecommerce.Application.Interfaces.Common;
using Solid.Ecommerce.Infrastructure.Context;
using Solid.Ecommerce.Shared;

SolidEcommerceDbContext GetInstanceDb()
{
    return new SolidEcommerceDbContext();
}


DbFactoryContext dbFactoryContext = new DbFactoryContext(()=> new SolidEcommerceDbContext());
IApplicationDBContext db = new ApplicationDbContext(dbFactoryContext);

IRepository<Product> repo = new Repository<Product>(db);
var data = repo.Find(1);

var products = repo.Entities.ToList();
/*
foreach (var i in products)
{
    Console.WriteLine($"Product Id: {i.ProductId}, Name: {i.Name}");
}
*/
Console.WriteLine($"Product Id: {data.ProductId}, Name: {data.Name}");

Console.ReadLine();

