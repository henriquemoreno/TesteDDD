using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Infra.Data.Context;

namespace Teste.DDD.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MyContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(MyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            var objRet = await DbSet.AddAsync(obj);
            return objRet.Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> obj)
        {
            await DbSet.AddRangeAsync(obj);
            return obj;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllPaged(int s, int t)
        {
            return await DbSet.AsNoTracking().Skip(s).Take(t).ToListAsync();
        }

        public virtual TEntity Update(TEntity obj)
        {
            Db.Update(obj);
            return obj;
        }

        public virtual void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
