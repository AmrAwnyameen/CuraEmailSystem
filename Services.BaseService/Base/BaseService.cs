using Core.Domain.Context;
using Core.Interfaces.IRepository;
using Core.InterFaces.IAudit;
using Services.Interfaces.IBaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IRepository<TEntity> Repository
        {
            get { return _unitOfWork.Repository<TEntity>(); }
        }
        public virtual TEntity Add(TEntity entity)
        {
            UpdateAudit(entity, true);
           _unitOfWork.Repository<TEntity>().Add(entity);
            SaveChanges();
            return entity;
        }


        List<TEntity> IBaseService<TEntity>.AddRange(List<TEntity> entities)
        {
            UpdateAudit(entities.FirstOrDefault(), true);
            _unitOfWork.Repository<TEntity>().AddRange(entities);
            SaveChanges();
            return entities;
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            UpdateAudit(entity, true);
            await _unitOfWork.Repository<TEntity>().AddAsync(entity);
            SaveChanges();
            return entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            UpdateAudit(entities?.FirstOrDefault(), true);
            await _unitOfWork.Repository<TEntity>().AddRangeAsync(entities);
             SaveChanges();
            return entities;
        }

        //

        public TEntity Update(TEntity entity)
        {
            UpdateAudit(entity, true);
            _unitOfWork.Repository<TEntity>().Update(entity);
            SaveChanges();
            return entity;
        }


        public TEntity GetById(string id)
        {
            var entity = _unitOfWork.Repository<TEntity>().GetById(id);
            _unitOfWork.SaveAsync();
            return entity;
        }
        //

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public virtual async Task Remove(TEntity entity)
        {
            UpdateAudit(entity, true);
            await _unitOfWork.Repository<TEntity>().Remove(entity);
            await _unitOfWork.SaveAsync();

        }

        public async Task RemoveByIdAsync(string id)
        {
            await _unitOfWork.Repository<TEntity>().RemoveByIdAsync(id);
            await _unitOfWork.SaveAsync();

        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().FirstOrDefault(predicate);

        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().SingleOrDefaultAsync(predicate);

        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().AnyAsync(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Repository<TEntity>().Any(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.Repository<TEntity>().GetAll();
        }



        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _unitOfWork.Repository<TEntity>().Where(filter, orderBy, includeProperties);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _unitOfWork.Repository<TEntity>().Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _unitOfWork.Repository<TEntity>().CountAsync(predicate);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Repository<TEntity>().IsExistAsync(predicate);
        }


        public virtual void SaveChanges()
        {
             _unitOfWork.Save();
        }
        private void UpdateAudit(TEntity entity, bool isNew, string userId = null)
        {
            if (entity!=null && entity is IAudit model )
            {
                if (isNew)
                {
                    model.CreatedBy = _unitOfWork.Repository<ApplicationUser>().FirstOrDefault(s => s.UserName.Equals(HttpContext.Current.User.Identity.Name))?.UserName ?? "Anonymous";
                    model.CreatedDate = DateTime.Now;
                }
                else
                {
                    model.UpdatedBy = _unitOfWork.Repository<ApplicationUser>().FirstOrDefault(s => s.UserName.Equals(HttpContext.Current.User.Identity.Name))?.UserName ?? "Anonymous";
                    model.UpdatedDate = DateTime.Now;
                }
            }
        }

        private void DeleteAudit(TEntity entity, bool isNew, string userId = null)
        {
            if (entity is IDeleteEntity model)
            {
                if (isNew)
                {
                    model.DeletedBy = _unitOfWork.Repository<ApplicationUser>().FirstOrDefault(s => s.UserName.Equals(HttpContext.Current.User.Identity.Name))?.UserName ?? "Anonymous";
                    model.DeletedDate = DateTime.Now;
                    model.IsDeleted = true;
                }
                else
                {
                    model.DeletedBy = _unitOfWork.Repository<ApplicationUser>().FirstOrDefault(s => s.UserName.Equals(HttpContext.Current.User.Identity.Name))?.UserName ?? "Anonymous";
                    model.DeletedDate = DateTime.Now;
                    model.IsDeleted = true;
                }
            }
        }

        public IQueryable<TEntity> Include(Expression<Func<TEntity, object>> predicate)
        {
            return  _unitOfWork.Repository<TEntity>().Include(predicate);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _unitOfWork.Repository<TEntity>().UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
