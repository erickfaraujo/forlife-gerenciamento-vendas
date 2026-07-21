using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;

public record AtualizarClienteRequest(int Id, string Telefone, string Email, DateTime? DtNascimento, Guid? IdLocal) : IRequest<Result<AtualizarClienteResponse>>;