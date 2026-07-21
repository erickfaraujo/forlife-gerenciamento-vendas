using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForlifeGerenciamentoVendas.Data.Repositories;

public class ClienteRepository(ForlifeDbContext context) : IClienteRepository
{
    private readonly ForlifeDbContext _context = context;

    public async Task CadastrarClienteAsync(Cliente cliente)
    {
        _context.Cliente.Add(cliente);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Cliente>> ConsultarClientesAsync(int? id, Guid? idLocal, string? nome, string? telefone)
    {
        // 1. Criamos a query base sem executar no banco ainda (AsNoTracking melhora a performance em consultas de leitura)
        IQueryable<Cliente> query = _context.Cliente.AsNoTracking();

        // 2. Aplicamos os filtros dinamicamente conforme forem preenchidos
        if (id.HasValue)
            query = query.Where(c => c.IdCliente == id.Value);

        if (idLocal is not null)
            query = query.Where(c => c.IdLocal == idLocal);

        if (!string.IsNullOrWhiteSpace(nome))
            query = query.Where(c => c.Nome.Contains(nome));

        if (!string.IsNullOrWhiteSpace(telefone))
            query = query.Where(c => c.Telefone == telefone);

        return await query.Include(x => x.LocalVenda).ToListAsync();
    }

    public async Task<Cliente?> ConsultarDetalhesClienteAsync(int Id)
        => await _context.Cliente
            .AsNoTracking()
            .Include(x => x.LocalVenda)
            .FirstOrDefaultAsync(x => x.IdCliente == Id);

    public async Task AtualizarClienteAsync(Cliente cliente)
    {
        _context.Cliente.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirClienteAsync(int idCliente)
    {
        await context.Cliente
            .Where(x => x.IdCliente == idCliente)
            .ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
    }
}
