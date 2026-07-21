using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Shareable.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForlifeGerenciamentoVendas.Data.EntityMapConfig;

public class TbPagamentoEntityMapConfiguraTbPagamentoEntityMapConfigurationtion : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
        builder.Property(x => x.IdVenda).HasColumnName("Id_Venda").IsRequired();
        builder.Property(x => x.NumParcela).HasColumnName("Num_Parcela").IsRequired();
        builder.Property(x => x.Status).HasColumnName("Status_Pagamento").HasConversion<byte>().HasDefaultValue(StatusPagamentoEnum.Pendente).IsRequired();
        builder.Property(x => x.DataPromessaPagamento).HasColumnName("Data_Promessa_Pagamento").IsRequired();
        builder.Property(x => x.DataPagamento).HasColumnName("Data_Pagamento");
        builder.Property(x => x.ValorParcela).HasColumnName("Valor_Parcela").HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.ValorPago).HasColumnName("Valor_Pago").HasColumnType("decimal(18,2)");
        builder.Property(x => x.FormaPagamento).HasColumnName("Forma_Pagamento").HasMaxLength(50);

        builder.HasOne(p => p.Venda)
               .WithMany(v => v.Pagamentos)
               .HasForeignKey(p => p.IdVenda)
               .HasConstraintName("FK_TB_PAGAMENTO_TB_VENDA")
               .OnDelete(DeleteBehavior.Cascade);
    }
}