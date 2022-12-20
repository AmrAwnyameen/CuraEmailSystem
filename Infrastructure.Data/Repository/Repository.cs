using Core.Domain.Context;
using Core.Interfaces.IRepository;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly ApplicationDbContext _context;
        private  DbSet<TEntity> dbset;
        private DbContext context;

       
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        protected DbSet<TEntity> Table
        {
            get
            {
                if (dbset == null)
                {
                    dbset = _context.Set<TEntity>();
                }

                return dbset;
            }
        }

        public Repository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Table.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
        }

        public async Task  AddAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                Table.Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            });
        }

        public void AddRange(List<TEntity> entities)
        {
            Table.AddRange(entities);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await Task.Run(() =>
            {
                Table.AddRange(entities);
            });
           
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Any(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.AnyAsync(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Table.Count(predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Table.CountAsync(predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            
            return Table.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
           
            return Table.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public TEntity GetById(string id)
        {

            return Table.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await AnyAsync(predicate);
        }

        public async Task Remove(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                Table.Attach(entity);
            }
            await Task.Run(() =>
            {
                Table.Remove(entity);
            });
        }

        public async Task RemoveByIdAsync(string id)
        {

            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            await Remove(entity);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> predicate)
        {
            return Table.Include(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
           Table.Attach(entity);
           _context.Entry(entity).State = EntityState.Modified;
        }


        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;

            if (filter != null)
            {
                query = Table.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public virtual void Load(TEntity entity, string navigationProperty)
        {
            context.Entry(entity).Reference(navigationProperty).Load();
        }

        public virtual void LoadCollection(TEntity entity, string collection)
        {
            context.Entry(entity).Collection(collection).Load();
        }
        public virtual void LoadCollection(TEntity entity, string[] collection)
        {
            foreach (var property in collection)
            {
                context.Entry(entity).Collection(property).Load();
            }
        }

        public virtual void Load(TEntity entity, string[] navigationProperties)
        {
            foreach (var property in navigationProperties)
            {
                Load(entity, property);
            }
        }

        public virtual void Load<TProperty>(TEntity entity, System.Linq.Expressions.Expression<Func<TEntity, TProperty>> navigationProperty) where TProperty : class
        {
            context.Entry(entity).Reference(navigationProperty).Load();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                
            });
        }
    }
}
