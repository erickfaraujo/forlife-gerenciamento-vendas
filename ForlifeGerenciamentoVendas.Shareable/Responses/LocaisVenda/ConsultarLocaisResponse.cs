namespace ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;

public record ConsultarLocaisResponse(IEnumerable<LocaisResponse> LocaisVenda);

public record LocaisResponse(Guid Id, string Descricao, string Endereco);