using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IRepository
{
    public interface IRepository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        Task  AddAsync(TEntity entity);

        Task AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);

        Task  UpdateAsync(TEntity entity);

        TEntity GetById(string id);

        Task<TEntity> GetByIdAsync(string id);

        Task Remove(TEntity entity);

        Task RemoveByIdAsync(string id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Include(Expression<Func<TEntity, object>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);


        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);

        void Load(TEntity entity, string navigationProperty);

        void Load(TEntity entity, string[] navigationProperties);

        void LoadCollection(TEntity entity, string collection);
        void LoadCollection(TEntity entity, string[] collection);

        void Load<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty) where TProperty : class;

    }
}
