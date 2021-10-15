using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.DDD.Domain.Models;
using TesteDDD.Application.ViewModels;

namespace TesteDDD.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
