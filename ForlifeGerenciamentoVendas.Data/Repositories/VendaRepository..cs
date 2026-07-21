using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForlifeGerenciamentoVendas.Data.Repositories;

public class VendaRepository(ForlifeDbContext context) : IVendaRepository
{
    private readonly ForlifeDbContext _context = context;

    public async Task InserirVendaAsync(Venda venda)
    {
        _context.Venda.Add(venda);
        _context.SaveChanges();
    }
}
