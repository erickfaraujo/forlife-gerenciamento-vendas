using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForlifeGerenciamentoVendas.Data.Repositories;

public class LocalVendaRepository(ForlifeDbContext context) : ILocalVendaRepository
{
    private readonly ForlifeDbContext _context = context;

    public async Task CadastrarLocalAsync(LocalVenda localVenda)
    {
        _context.LocalVenda.Add(localVenda);
        _context.SaveChanges();
    }

    public async Task<LocalVenda?> ConsultaLocalAsync(Guid Id)
        => await _context.LocalVenda.AsNoTracking().FirstOrDefaultAsync(x => x.IdLocal == Id);

    public async Task<IEnumerable<LocalVenda>?> ConsultarLocaisAsync(string? Descricao)
    {
        var query = _context.LocalVenda.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(Descricao))
            query = query.Where(x => x.Descricao.Contains(Descricao));

        return await query.ToListAsync();
    }
}
