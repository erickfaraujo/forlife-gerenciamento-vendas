using ForlifeGerenciamentoVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForlifeGerenciamentoVendas.Data.EntityMapConfig;

public class TbLocalVendaEntityMapConfiguration : IEntityTypeConfiguration<LocalVenda>
{
    public void Configure(EntityTypeBuilder<LocalVenda> builder)
    {
        builder.ToTable("TB_LOCALVENDA");

        builder.HasKey(x => x.IdLocal);

        builder.Property(x => x.IdLocal).HasColumnName("Id").ValueGeneratedOnAdd();
        builder.Property(x => x.Descricao).HasColumnName("Descricao").HasMaxLength(150).IsRequired();
        builder.Property(x => x.Endereco).HasColumnName("Endereco").HasMaxLength(255).IsRequired();
    }
}
