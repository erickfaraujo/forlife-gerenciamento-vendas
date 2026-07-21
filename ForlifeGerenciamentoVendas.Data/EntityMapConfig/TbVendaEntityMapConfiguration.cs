using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Shareable.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForlifeGerenciamentoVendas.Data.EntityMapConfig;

public class TbVendaEntityMapConfiguration : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.ToTable("TB_VENDA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
        builder.Property(x => x.IdCliente).HasColumnName("Id_Cliente").IsRequired();
        builder.Property(x => x.DataVenda).HasColumnName("Data_Venda").HasDefaultValueSql("GETDATE()").IsRequired();
        builder.Property(x => x.ValorVenda).HasColumnName("Valor_Venda").HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.Status).HasColumnName("Status_Venda").HasConversion<byte>().HasDefaultValue(StatusVendaEnum.Pendente).IsRequired();
        builder.Property(x => x.DataAtualizacao).HasColumnName("Data_Atualizacao");

        builder.HasOne(v => v.Cliente)
               .WithMany(c => c.Vendas)
               .HasForeignKey(v => v.IdCliente)
               .HasConstraintName("FK_TB_VENDA_TB_CLIENTE");
    }
}