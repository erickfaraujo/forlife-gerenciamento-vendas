using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;

public record ConsultarDetalhesLocalRequest(string Id) : IRequest<Result<ConsultarDetalhesLocalResponse>>;

