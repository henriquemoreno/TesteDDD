using Teste.DDD.Domain.Models;

namespace Teste.DDD.Domain.Interfaces.Service
{
    public interface IProdutoService : IService<Produto>
    {
        bool Exists(string nome);
    }
}
