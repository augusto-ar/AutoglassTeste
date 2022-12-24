using Microsoft.EntityFrameworkCore;
using AutoglassTeste.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoglassTeste.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Codigo);
            builder.Property(c => c.DescricaoProduto).HasMaxLength(200);
            builder.Property(c => c.SituacaoProduto);
            builder.Property(c => c.DataValidade);
            builder.Property(c => c.DataFabricacao);
            builder.Property(c => c.CodigoFornecedor);
            builder.Property(c => c.DescricaoFornecedor).HasMaxLength(200);
            builder.Property(c => c.CNPJFornecedor).HasMaxLength(14);
        }
    }
}
