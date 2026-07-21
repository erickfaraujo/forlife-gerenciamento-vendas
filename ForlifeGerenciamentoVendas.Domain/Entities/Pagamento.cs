using ForlifeGerenciamentoVendas.Shareable.Enums;

namespace ForlifeGerenciamentoVendas.Domain.Entities;

public class Pagamento
{
    public Guid Id { get; set; }
    public Guid IdVenda { get; set; }
    public int NumParcela { get; set; }
    public StatusPagamentoEnum Status { get; set; }
    public DateTime DataPromessaPagamento { get; set; }
    public DateTime? DataPagamento { get; set; }
    public decimal ValorParcela { get; set; }
    public decimal? ValorPago { get; set; }
    public string? FormaPagamento { get; set; }
    public virtual Venda Venda { get; set; } = default!;
}