using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.DDD.Domain.Models;
using TesteDDD.Application.ViewModels;

namespace TesteDDD.Application.Interfaces
{
    public interface IProdutoAppService : IAppService<Produto>
    {
        Task<IEnumerable<ProdutoViewModel>> GetAllProdutos();
        Task<ProdutoViewModel> AddProduto(ProdutoViewModel produto);
        Task<ProdutoViewModel> GetByIdProduto(Guid id);
        Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produto);
        Task RemoveProduto(Guid id);
    }
}
