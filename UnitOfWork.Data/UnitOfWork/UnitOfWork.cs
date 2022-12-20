using Core.Domain.Context;
using Core.Interfaces.IRepository;
using Elmah;
using Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UnitOfWork.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();
        private DbContextTransaction _transaction;
        private bool _disposed;
        public void Commit()
        {
            _transaction.Commit();
        }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public void CreateTransaction()
        {

            _transaction = _context.Database.BeginTransaction();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }



        public void Save()
        {
            try
            {
                using (_transaction = _context.Database.BeginTransaction())
                {
                    _context.SaveChanges();
                    foreach (var entity in _context.ChangeTracker.Entries())
                    {
                        entity.Reload();
                    }
                    Commit();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.Reload();
                }
            }

            catch (Exception ex)
            {
                RollBack();
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }

        }



        public async Task SaveAsync()
        {
            try
            {
                using (_transaction = _context.Database.BeginTransaction())
                {
                    await _context.SaveChangesAsync();
                    foreach (var entity in _context.ChangeTracker.Entries())
                    {
                        entity.Reload();
                    }
                    Commit();
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.Reload();
                }


            }
            catch (Exception ex)
            {
                RollBack();

                throw new Exception(ex.InnerException?.Message);
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var entityName = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityName))
            {
                _repositories.Add(entityName, new Repository<TEntity>(_context));
            }

            return _repositories[entityName] as IRepository<TEntity>;
        }


   
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

               
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ApplicationDbContext MainContext()
        {
            return _context;
        }
    }
}
