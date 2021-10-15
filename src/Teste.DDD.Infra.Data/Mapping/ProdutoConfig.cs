using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.DDD.Domain.Models;

namespace Teste.DDD.Infra.Data.Mapping
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Preco).HasPrecision(18, 3);
        }
    }
}
