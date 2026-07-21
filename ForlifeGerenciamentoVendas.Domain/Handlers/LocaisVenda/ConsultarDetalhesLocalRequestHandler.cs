using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;
using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.LocaisVenda;

public class ConsultarDetalhesLocalRequestHandler : IRequestHandler<ConsultarDetalhesLocalRequest, Result<ConsultarDetalhesLocalResponse>>
{
    private readonly ILocalVendaRepository _localVendaRepository;

    public ConsultarDetalhesLocalRequestHandler(ILocalVendaRepository localVendaRepository)
        => _localVendaRepository = localVendaRepository;

    public async Task<Result<ConsultarDetalhesLocalResponse>> Handle(ConsultarDetalhesLocalRequest request, CancellationToken cancellationToken)
    {
        var local = await _localVendaRepository.ConsultaLocalAsync(Guid.Parse(request.Id));

        return local is null
            ? new LocalNaoLocalizadoException()
            : new ConsultarDetalhesLocalResponse(local.IdLocal, local.Descricao, local.Endereco);
    }
}