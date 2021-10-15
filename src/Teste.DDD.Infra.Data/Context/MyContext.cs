using Microsoft.EntityFrameworkCore;
using Teste.DDD.Domain.Models;
using Teste.DDD.Infra.Data.Mapping;

namespace Teste.DDD.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoConfig().Configure);
        }
    }
}
