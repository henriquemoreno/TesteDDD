using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Domain.Interfaces.Service;

namespace Teste.DDD.Domain.Services
{
    public class Service<TEntity> : IDisposable, IService<TEntity> where TEntity : class
    {

        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _repository.Add(obj);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> obj)
        {
            await _repository.AddRange(obj);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllPaged(int s, int t)
        {
            return await _repository.GetAllPaged(s, t);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _repository.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Search(predicate);
        }

        public TEntity Update(TEntity obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
