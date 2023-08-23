using FullstackAfiliados.Business.Models;
using System.Linq.Expressions;

namespace FullstackAfiliados.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Create(TEntity entity);

    Task<TEntity> GetById(int id);

    Task<List<TEntity>> GetAll();

    Task Update(TEntity entity);

    Task Remove(int id);

    Task<IEnumerable<TEntity>> SearchBy(Expression<Func<TEntity, bool>> predicate);

    Task<int> SaveChanges();
}