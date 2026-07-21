using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;
using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.LocaisVenda;

public class ConsultarLocaisRequestHandler(ILocalVendaRepository localVendaRepository) : IRequestHandler<ConsultarLocaisRequest, Result<ConsultarLocaisResponse>>
{
    private readonly ILocalVendaRepository _localVendaRepository = localVendaRepository;

    public async Task<Result<ConsultarLocaisResponse>> Handle(ConsultarLocaisRequest request, CancellationToken cancellationToken)
    {
        var locais = await _localVendaRepository.ConsultarLocaisAsync(request.Descricao);

        if (locais is null) return new LocalNaoLocalizadoException();

        var locaisResponse = locais.Select(x => new LocaisResponse(x.IdLocal, x.Descricao, x.Endereco));

        return locais is null || !locais.Any()
            ? new LocalNaoLocalizadoException()
            : new ConsultarLocaisResponse(locaisResponse.OrderBy(x => x.Descricao));
    }
}