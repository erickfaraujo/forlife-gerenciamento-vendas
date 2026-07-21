using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;

public record CadastrarLocalRequest(string Descricao, string Endereco) : IRequest<Result<CadastrarLocalResponse>>;
