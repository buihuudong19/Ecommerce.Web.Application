using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using SolidEdu.Shared;

//viet ham de lay ra toan bo categories
static void QueryCategories()
{
    //1. khai bao bien de access to db
    SolidStoreContext context = new();//c#9.0
    //2. lay data dua vao 1 collection
    List<Category> categories = context.Categories.ToList();
    IQueryable<Category> categoriesQuery = context.Categories.Include(c=>c.Products) ;
    IEnumerable<Category> categoriesIEnum = context.Categories.Include(c => c.Products).ToList();
    categoriesIEnum = categoriesIEnum.Where(c => c.CategoryId >= 5)
        .OrderByDescending(c=>c.CategoryName);
    foreach (Category c in categoriesIEnum)
    {
        /*
        foreach(Product p in c.Products)
        {
            WriteLine(p.ProductName);
        }
        */
        WriteLine($"Category ID: {c.CategoryId} - Category Name: {c.CategoryName}");
    }
    
    ReadLine();
}

static bool AddProduct(int categoryId, string productName, decimal? price)
{
    using (SolidStoreContext db = new())
    {
        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            UnitPrice = price
        };
        // mark product as added in change tracking
        db.Products.Add(p);
        // save tracked change to database
        int affected = db.SaveChanges();// => Unit of work design parttern
        return (affected == 1);
    }
}

if (AddProduct(categoryId: 6,productName: "Bui Huu Dong", price: 50M))
{
    WriteLine("Add product successful.");
}
else
{
    WriteLine("Trapped error");
}

//QueryCategories();





