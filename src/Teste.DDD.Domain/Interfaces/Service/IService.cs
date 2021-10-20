using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Teste.DDD.Domain.Interfaces.Service
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        Task<ValidationResult> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllPaged(int s, int t);
        TEntity Update(TEntity obj);
        void Delete(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
