using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Cliente;

public class ConsultarDetalhesClienteRequestHandler(IClienteRepository clienteRepository, ILogger<ConsultarDetalhesClienteRequestHandler> logger) : IRequestHandler<ConsultarDetalhesClienteRequest, Result<ClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<ConsultarDetalhesClienteRequestHandler> _logger = logger;

    public async Task<Result<ClienteResponse>> Handle(ConsultarDetalhesClienteRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando consulta de cliente");

        var cliente = await _clienteRepository.ConsultarDetalhesClienteAsync(request.Id);

        _logger.LogInformation("Retornando detalhes do cliente");

        return cliente is not null
            ? new ClienteResponse(cliente.IdCliente, cliente.Nome, cliente.Telefone, cliente.DtNascimento, cliente.Email, cliente.LocalVenda.IdLocal, cliente.LocalVenda.Descricao)
            : new ClienteNaoLocalizadoException();
    }
}