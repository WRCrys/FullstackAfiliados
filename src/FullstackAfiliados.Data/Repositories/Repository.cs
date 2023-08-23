using System.Linq.Expressions;
using FullstackAfiliados.Business.Interfaces;
using FullstackAfiliados.Business.Models;
using FullstackAfiliados.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly FullstackAfiliadosDbContext Db;
    protected readonly DbSet<TEntity> DbSet;
    
    protected Repository(FullstackAfiliadosDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }
    
    public void Dispose()
    {
        Db?.Dispose();
    }

    public async Task Create(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public async Task Remove(int id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> SearchBy(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<int> SaveChanges() => await Db.SaveChangesAsync();
}