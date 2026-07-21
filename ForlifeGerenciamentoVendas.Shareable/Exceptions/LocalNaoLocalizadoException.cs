namespace ForlifeGerenciamentoVendas.Shareable.Exceptions;

public class LocalNaoLocalizadoException : BaseException
{
    public LocalNaoLocalizadoException() : base("Local informado não está cadastrado no sistema")
    {
    }
}
