using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;

public record ConsultarDetalhesClienteRequest(int Id) : IRequest<Result<ClienteResponse>>;