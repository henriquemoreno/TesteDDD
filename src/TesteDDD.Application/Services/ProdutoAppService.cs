using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Domain.Models;
using Teste.DDD.Infra.Data.Interfaces;
using TesteDDD.Application.Interfaces;
using TesteDDD.Application.ViewModels;

namespace TesteDDD.Application.Services
{
    public class ProdutoAppService :  AppService<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService,
                                 IUnitOfWork uow,
                                 IMapper mapper) : base(uow, produtoService)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.GetAll());
        }

        public async Task<ProdutoViewModel> AddProduto(ProdutoViewModel produto)
        {
            await _produtoService.Add(_mapper.Map<Produto>(produto));

            await Commit();

            return produto;
        }

        public async Task<ProdutoViewModel> GetByIdProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoService.GetById(id));
        }

        public async Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produto)
        {
             _produtoService.Update(_mapper.Map<Produto>(produto));

            await Commit();

            return produto;
        }

        public async Task RemoveProduto(Guid id)
        {
            _produtoService.Delete(id);

            await Commit();
        }
    }
}
