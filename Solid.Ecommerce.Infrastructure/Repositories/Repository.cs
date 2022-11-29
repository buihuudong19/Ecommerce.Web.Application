namespace Solid.Ecommerce.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    public IApplicationDBContext ApplicationDBContext { get; private set; }
    public DbSet<T> Entities => ApplicationDBContext.DbContext.Set<T>();

    public Repository(IApplicationDBContext applicationDBContext)
    {
        ApplicationDBContext = applicationDBContext;
    }
    public async Task DeleteAsync(int id, bool saveChange = true)
    {
        var entity = await Entities.FindAsync(id); 
        await DeleteAsync(entity);
        if(saveChange)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(T entity, bool saveChange = true)
    {
        Entities.Remove(entity);
        if (saveChange)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChange = true)
    {
        // is, or, as, in..
       var enumerable = entities as T[] ?? entities.ToArray();
        if (enumerable.Any())
        {
            Entities.RemoveRange(enumerable);
        }
        if (saveChange) 
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync(); 
        }
    }

    public T Find(params object[] keyValues) => Entities.Find(keyValues);

    public virtual async Task<T> FindAsync(params object[] keyValues) => await Entities.FindAsync(keyValues);


    public async Task<IList<T>> GetAllAsync() => await Entities.ToListAsync<T>();
   

    public async Task InsertAsync(T entity, bool saveChange = true)
    {
        await Entities.AddAsync(entity);
        if (saveChange)
        {
            //luu du lieu xuong database thong qua EFC duoi dang asyncronous
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChange = true)
    {
        await ApplicationDBContext.DbContext.AddRangeAsync(entities);
        if (saveChange)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity, bool saveChange = true)
    {
        Entities.Update(entity);
        if (saveChange)
        {
            await ApplicationDBContext.DbContext.SaveChangesAsync();    
        }
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChange = true)
    {
        Entities.UpdateRange(entities);
    }
}
