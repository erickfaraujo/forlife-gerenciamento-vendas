using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Cliente;

public class ExcluirClienteRequestHandler(IClienteRepository clienteRepository, ILogger<ExcluirClienteRequestHandler> logger) : IRequestHandler<ExcluirClienteRequest, Result<ExcluirClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<ExcluirClienteRequestHandler> _logger = logger;

    public async Task<Result<ExcluirClienteResponse>> Handle(ExcluirClienteRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando exclusão do cliente");

        try
        {
            await _clienteRepository.ExcluirClienteAsync(request.IdCliente);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir cliente");
            return new ExcluirClienteException();
        }

        return new ExcluirClienteResponse();
    }
}