using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Venda;
using ForlifeGerenciamentoVendas.Shareable.Responses.Venda;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Venda;

public class RegistrarVendaRequestHandler(IVendaRepository vendaRepository, ILogger<RegistrarVendaRequestHandler> logger) : IRequestHandler<RegistrarVendaRequest, Result<RegistrarVendaResponse>>
{
    private readonly IVendaRepository _vendaRepository = vendaRepository;
    private readonly ILogger<RegistrarVendaRequestHandler> _logger = logger;

    public async Task<Result<RegistrarVendaResponse>> Handle(RegistrarVendaRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando registro de venda");

        try
        {
            await _vendaRepository.InserirVendaAsync(new());
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Ocorreu um erro ao cadastrar o cliente no banco de dados. Erro: {erro}", e.Message);
            return new CadastrarClienteException();
        }

        return new RegistrarVendaResponse();

    }
}