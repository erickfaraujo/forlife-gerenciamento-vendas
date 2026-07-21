using ForlifeGerenciamentoVendas.Domain.Entities;

namespace ForlifeGerenciamentoVendas.Domain.Repositories;

public interface IClienteRepository
{
    Task CadastrarClienteAsync(Cliente cliente);
    Task<IEnumerable<Cliente>> ConsultarClientesAsync(int? id, Guid? idLocal, string? nome, string? telefone);
    Task<Cliente?> ConsultarDetalhesClienteAsync(int Id);
    Task AtualizarClienteAsync(Cliente cliente);
    Task ExcluirClienteAsync(int idCliente);
}
