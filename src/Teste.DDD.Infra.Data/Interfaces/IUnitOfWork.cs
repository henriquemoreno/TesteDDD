using System.Threading.Tasks;

namespace Teste.DDD.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task Commit();
    }
}
