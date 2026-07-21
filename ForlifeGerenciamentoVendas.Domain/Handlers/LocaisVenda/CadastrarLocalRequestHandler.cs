using ForlifeGerenciamentoVendas.Domain.Entities;
using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;
using ForlifeGerenciamentoVendas.Shareable.Responses.LocaisVenda;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.LocaisVenda;

public class CadastrarLocalRequestHandler(ILocalVendaRepository localVendaRepository, ILogger<CadastrarLocalRequestHandler> logger) : IRequestHandler<CadastrarLocalRequest, Result<CadastrarLocalResponse>>
{
    private readonly ILocalVendaRepository _localVendaRepository = localVendaRepository;
    private readonly ILogger<CadastrarLocalRequestHandler> _logger = logger;

    public async Task<Result<CadastrarLocalResponse>> Handle(CadastrarLocalRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando cadastro de local");

        var localVenda = new LocalVenda()
        {
            Descricao = request.Descricao,
            Endereco = request.Endereco,
        };

        await _localVendaRepository.CadastrarLocalAsync(localVenda);
        _logger.LogInformation("Cadastro de local realizado com sucesso!");

        return new CadastrarLocalResponse(localVenda.IdLocal);
    }
}