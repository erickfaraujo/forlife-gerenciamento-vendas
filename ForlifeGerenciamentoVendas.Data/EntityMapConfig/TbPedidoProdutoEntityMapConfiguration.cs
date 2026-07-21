using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Shareable.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForlifeGerenciamentoVendas.Data.EntityMapConfig;

public class TbPedidoProdutoEntityMapConfiguration : IEntityTypeConfiguration<PedidoProduto>
{
    public void Configure(EntityTypeBuilder<PedidoProduto> builder)
    {
        builder.ToTable("TB_PEDIDO_PRODUTO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
        builder.Property(x => x.IdVenda).HasColumnName("Id_Venda").IsRequired();
        builder.Property(x => x.IdProduto).HasColumnName("Id_Produto").IsRequired();

        builder.HasOne(pp => pp.Venda)
                .WithMany(v => v.PedidosProdutos)
                .HasForeignKey(pp => pp.IdVenda)
                .HasConstraintName("FK_TB_PEDIDOPRODUTO_TB_VENDA")
                .OnDelete(DeleteBehavior.Cascade);
    }
}