namespace ForlifeGerenciamentoVendas.Shareable.Exceptions;

public class PedidoNaoLocalizadoException : BaseException
{
    public PedidoNaoLocalizadoException() : base("Pedido não encontrado")
    {
    }
}
