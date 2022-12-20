using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IBaseServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        Task UpdateAsync(TEntity entity);
        List<TEntity> AddRange(List<TEntity> entities);

       Task<TEntity> AddAsync(TEntity entity);
      Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);

        TEntity GetById(string id);

        Task<TEntity> GetByIdAsync(string id);

        Task Remove(TEntity entity);

        Task  RemoveByIdAsync(string id);

        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
