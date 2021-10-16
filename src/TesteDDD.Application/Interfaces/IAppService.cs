using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TesteDDD.Application.Interfaces
{
    public interface IAppService<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllPaged(int s, int t);
        TEntity Update(TEntity obj);
        void Delete(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
        void Dispose();
    }
}
