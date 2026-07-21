namespace ForlifeGerenciamentoVendas.Domain.Entities;

public class Cliente
{
    public int IdCliente { get; init; }
    public string Nome { get; set; } = default!;
    public string Telefone { get; set; } = default!;
    public DateTime? DtNascimento { get; set; }
    public string? Email { get; set; }
    public Guid IdLocal { get; set; } = default!;

    public virtual LocalVenda LocalVenda { get; set; } = default!;
    public virtual ICollection<Venda> Vendas { get; set; } = [];
}
