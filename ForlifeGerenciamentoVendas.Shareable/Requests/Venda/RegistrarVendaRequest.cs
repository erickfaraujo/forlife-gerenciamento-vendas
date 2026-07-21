using ForlifeGerenciamentoVendas.Shareable.Responses.Venda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Shareable.Requests.Venda;

public record RegistrarVendaRequest(IEnumerable<Item>? Itens, decimal ValorTotal, decimal ValorPago, int IdCliente, string? Observacoes, string CodProdutos, DateTime DataPedido) : IRequest<Result<RegistrarVendaResponse>>;

public record Item(int CodigoProduto, int Quantidade);