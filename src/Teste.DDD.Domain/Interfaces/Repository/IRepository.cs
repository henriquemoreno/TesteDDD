using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Teste.DDD.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosPaginado(int s, int t);
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
