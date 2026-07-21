using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Cliente;

public class ConsultarClientesRequestHandler(IClienteRepository clienteRepository, ILogger<ConsultarClientesRequestHandler> logger) : IRequestHandler<ConsultarClientesRequest, Result<ConsultarClientesResponse>>
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<ConsultarClientesRequestHandler> _logger = logger;

    public async Task<Result<ConsultarClientesResponse>> Handle(ConsultarClientesRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando consulta de clientes");

        var clientes = await _clienteRepository.ConsultarClientesAsync(request.Id, request.IdLocal, request.Nome, request.Telefone);

        var response = new ConsultarClientesResponse();
        
        foreach (var cliente in clientes)
        {
            response.Clientes = response.Clientes.Append(new ClienteResponse(
                                                cliente.IdCliente,
                                                cliente.Nome,
                                                cliente.Telefone,
                                                cliente.DtNascimento,
                                                cliente.Email,
                                                cliente.LocalVenda.IdLocal,
                                                cliente.LocalVenda.Descricao));
        }

        return response;

    }
}