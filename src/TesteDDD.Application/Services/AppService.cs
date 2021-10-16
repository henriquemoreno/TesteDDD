using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Infra.Data.Interfaces;
using TesteDDD.Application.Interfaces;

namespace TesteDDD.Application.Services
{
    public abstract class AppService<TEntity> : IDisposable, IAppService<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> _service;
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow, IService<TEntity> serviceBase)
        {
            _uow = uow;
            _service = serviceBase;
        }

        public virtual async Task Commit()
        {
            await _uow.Commit();
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
             await _service.Add(obj);
            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> obj)
        {
            await _service.AddRange(obj);
            return obj;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllPaged(int s, int t)
        {
            return await _service.GetAllPaged(s, t);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _service.GetById(id);
        }

        public virtual void Delete(Guid id)
        {
            _service.Delete(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _service.Search(predicate);
        }

        public virtual TEntity Update(TEntity obj)
        {
            _service.Update(obj);
            return obj;
        }

        public virtual async Task<int> SaveChanges()
        {
            return await _service.SaveChanges();
        }

        public virtual void Dispose()
        {
            _service.Dispose();
        }
    }
}
