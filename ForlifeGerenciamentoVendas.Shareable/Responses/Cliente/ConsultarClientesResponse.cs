namespace ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;

public class ConsultarClientesResponse
{
    public int ClientesRetornados { get; set; }

    public IEnumerable<ClienteResponse> Clientes { get; set; } = default!;
}


