using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Domain.Models;
using Teste.DDD.Domain.Models.Validations;
using Teste.DDD.Infra.Data.Interfaces;
using TesteDDD.Application.Interfaces;
using TesteDDD.Application.ViewModels;

namespace TesteDDD.Application.Services
{
    public class ProdutoAppService :  AppService, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService,
                                 IUnitOfWork uow,
                                 IMapper mapper) : base(uow)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.GetAll());
        }

        public async Task<ValidationResult> AddProduto(ProdutoViewModel produto)
        {
           var result = await _produtoService.Add<ProdutoValidation>(_mapper.Map<Produto>(produto));

            if(result.IsValid) await Commit();

            return result;
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

        public void Dispose()
        {
            _produtoService.Dispose();
        }
    }
}
