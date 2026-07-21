namespace ForlifeGerenciamentoVendas.Domain.Entities;

public class PedidoProduto
{
    public Guid Id { get; set; }
    public Guid IdVenda { get; set; }
    public int IdProduto { get; set; }

    public virtual Venda Venda { get; set; } = default!;
}