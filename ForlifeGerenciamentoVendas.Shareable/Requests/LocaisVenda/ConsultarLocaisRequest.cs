using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;

public record ConsultarLocaisRequest(string? Descricao) : IRequest<Result<ConsultarLocaisResponse>>;

