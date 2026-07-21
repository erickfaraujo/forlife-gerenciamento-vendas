using ForlifeGerenciamentoVendas.Domain.Entities;

namespace ForlifeGerenciamentoVendas.Domain.Repositories;

public interface IVendaRepository
{
    Task InserirVendaAsync(Venda venda);
}
