namespace ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;

public record ClienteResponse(
    int IdCliente,
    string Nome,
    string Telefone,
    DateTime? DtNascimento,
    string? Email,
    Guid IdLocal,
    string NomeLocal);