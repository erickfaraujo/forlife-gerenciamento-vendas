using ForlifeGerenciamentoVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForlifeGerenciamentoVendas.Data.EntityMapConfig;

public class TbClienteEntityMapConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("TB_CLIENTE");
        
        builder.HasKey(x => x.IdCliente);

        builder.Property(x => x.IdCliente).HasColumnName("Id").ValueGeneratedOnAdd();
        builder.Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
        builder.Property(x => x.Telefone).HasColumnName("Telefone").HasMaxLength(20).IsRequired();
        builder.Property(x => x.DtNascimento).HasColumnName("Dt_Nascimento");
        builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100);

        builder.Property(x => x.IdLocal).HasColumnName("Id_Local").IsRequired();

        builder.HasOne(c => c.LocalVenda)
            .WithMany(l => l.Clientes)
            .HasForeignKey(c => c.IdLocal)
            .HasConstraintName("FK_TB_CLIENTE_TB_LOCALVENDA");
    }
}
