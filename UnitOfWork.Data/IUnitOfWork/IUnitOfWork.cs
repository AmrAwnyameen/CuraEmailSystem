using Core.Domain.Context;
using Core.Interfaces.IRepository;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace UnitOfWork.Data.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        void CreateTransaction();
        void Commit();
        void RollBack();

        ApplicationDbContext MainContext();

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
