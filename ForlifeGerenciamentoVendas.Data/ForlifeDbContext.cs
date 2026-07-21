using ForlifeGerenciamentoVendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForlifeGerenciamentoVendas.Data;

public class ForlifeDbContext(DbContextOptions<ForlifeDbContext> options) : DbContext(options)
{
    public virtual DbSet<LocalVenda> LocalVenda { get; set; } = default!;
    public virtual DbSet<Cliente> Cliente { get; set; } = default!;
    public virtual DbSet<Venda> Venda { get; set; } = default!;
    public virtual DbSet<Pagamento> Pagamento { get; set; } = default!;
    public virtual DbSet<PedidoProduto> PedidoProduto { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForlifeDbContext).Assembly);
    }
}