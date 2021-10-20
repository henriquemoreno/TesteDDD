using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.DDD.Domain.Models;

namespace Teste.DDD.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        bool Exists(string nome);
    }
}
