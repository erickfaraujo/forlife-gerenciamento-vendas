using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;

public record CadastrarClienteRequest(string Nome, string Telefone, string? Email, DateTime? DataNascimento, Guid IdLocalVenda) : IRequest<Result<CadastrarClienteResponse>>;