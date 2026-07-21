namespace ForlifeGerenciamentoVendas.Domain.Entities;

public class LocalVenda
{
    public Guid IdLocal { get; init; } = default!;
    public string Descricao { get; init; } = default!;
    public string Endereco { get; init; } = default!;
    public virtual ICollection<Cliente> Clientes { get; set; } = [];
}
