using ForlifeGerenciamentoVendas.Shareable.Enums;

namespace ForlifeGerenciamentoVendas.Domain.Entities;

public class Venda
{
    public Guid Id { get; set; }
    public int IdCliente { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorVenda { get; set; }
    public StatusVendaEnum Status { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public virtual Cliente Cliente { get; set; } = default!;
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = [];
    public virtual ICollection<PedidoProduto> PedidosProdutos { get; set; } = [];
}
