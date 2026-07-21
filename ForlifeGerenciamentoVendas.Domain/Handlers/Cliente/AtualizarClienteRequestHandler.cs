using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Cliente;

public class AtualizarClienteRequestHandler(IClienteRepository clienteRepository, ILogger<AtualizarClienteRequestHandler> logger) : IRequestHandler<AtualizarClienteRequest, Result<AtualizarClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<AtualizarClienteRequestHandler> _logger = logger;

    public async Task<Result<AtualizarClienteResponse>> Handle(AtualizarClienteRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando atualizaçaõ de cliente");

        var cliente = await _clienteRepository.ConsultarDetalhesClienteAsync(request.Id);

        if (cliente is null)
        {
            _logger.LogWarning("Cliente não encontrado");
            return new ClienteNaoLocalizadoException();
        }

        cliente.Telefone = request.Telefone != null ? request.Telefone.Replace(" ", "") : cliente.Telefone;
        cliente.Email = request.Email ?? cliente.Email;
        cliente.DtNascimento = request.DtNascimento ?? cliente.DtNascimento;
        cliente.IdLocal = request.IdLocal ?? cliente.IdLocal;

        await _clienteRepository.AtualizarClienteAsync(cliente);

        throw new NotImplementedException();
    }
}