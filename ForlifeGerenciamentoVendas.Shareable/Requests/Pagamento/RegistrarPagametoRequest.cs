using ForlifeGerenciamentoVendas.Shareable.Responses.Pagamento;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Pagamento;

public record RegistrarPagametoRequest(Guid IdPedido) : IRequest<Result<RegistrarPagamentoResponse>>;