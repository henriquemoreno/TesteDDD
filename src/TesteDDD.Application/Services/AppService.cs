using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.DDD.Domain.Interfaces.Service;
using Teste.DDD.Infra.Data.Interfaces;
using TesteDDD.Application.Interfaces;

namespace TesteDDD.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public virtual async Task Commit()
        {
            await _uow.Commit();
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }
      
    }
}
