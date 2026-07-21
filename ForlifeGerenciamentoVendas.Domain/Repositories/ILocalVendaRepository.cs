using ForlifeGerenciamentoVendas.Domain.Entities;

namespace ForlifeGerenciamentoVendas.Domain.Repositories;

public interface ILocalVendaRepository
{

    Task CadastrarLocalAsync(LocalVenda localVenda);

    Task<LocalVenda?> ConsultaLocalAsync(Guid Id);

    Task<IEnumerable<LocalVenda>?> ConsultarLocaisAsync(string? Descricao);

}
