namespace ForlifeGerenciamentoVendas.Shareable.Exceptions;

public class ExcluirClienteComPedidoException : BaseException
{
    public ExcluirClienteComPedidoException() : base("Não é possível excluir um cliente com histórico de pedidos")
    {
    }
}
