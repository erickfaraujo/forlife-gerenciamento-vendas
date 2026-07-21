using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;

public record ExcluirClienteRequest(int IdCliente) : IRequest<Result<ExcluirClienteResponse>>;