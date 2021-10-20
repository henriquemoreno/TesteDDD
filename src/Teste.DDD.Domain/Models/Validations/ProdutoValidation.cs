using FluentValidation;
using Teste.DDD.Domain.Interfaces.Repository;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Domain.Services;

namespace Teste.DDD.Domain.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
                //.Must((nome) => _produtoService.Exists(nome)).WithMessage("Nome já cadastrado.");
                //.Must((nome) => { return UniqueName(nome); }).WithMessage("Nome já cadastrado.");

            RuleFor(c => c.Preco)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }

        //private bool UniqueName(string nome)
        //{
        //    return _produtoService.Exists(nome);
        //}
         
    }
}
