using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Domain.Models;

namespace Teste.DDD.Domain.Services
{
    public class ProdutoService : Service<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
    }
}
