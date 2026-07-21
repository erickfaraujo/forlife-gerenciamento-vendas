namespace ForlifeGerenciamentoVendas.Shareable.Exceptions;

public class BaseException : Exception
{
    public string Mensagem { get; set; }

    public BaseException(string mensagem) => Mensagem = mensagem;
}
