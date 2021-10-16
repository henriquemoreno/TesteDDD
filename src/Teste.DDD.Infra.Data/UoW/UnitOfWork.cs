using System;
using System.Threading.Tasks;
using Teste.DDD.Infra.Data.Context;
using Teste.DDD.Infra.Data.Interfaces;

namespace Teste.DDD.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private bool _disposed;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();
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
    }
}
