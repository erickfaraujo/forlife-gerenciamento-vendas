using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;

public record ConsultarClientesRequest(int? Id, Guid? IdLocal, string? Nome, string? Telefone) : IRequest<Result<ConsultarClientesResponse>>;