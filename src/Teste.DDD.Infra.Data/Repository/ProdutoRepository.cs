using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Domain.Models;
using Teste.DDD.Infra.Data.Context;

namespace Teste.DDD.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyContext context) : base(context)
        {
        }
        public bool Exists(string nome)
        {
            return DbSet.Any(i => i.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
