using ForlifeGerenciamentoVendas.Domain.Repositories;
using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using ForlifeGerenciamentoVendas.Shareable.Responses.Cliente;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace ForlifeGerenciamentoVendas.Domain.Handlers.Cliente;

public class CadastrarClienteRequestHandler(IClienteRepository clienteRepository, ILogger<CadastrarClienteRequestHandler> logger) : IRequestHandler<CadastrarClienteRequest, Result<CadastrarClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;
    private readonly ILogger<CadastrarClienteRequestHandler> _logger = logger;

    public async Task<Result<CadastrarClienteResponse>> Handle(CadastrarClienteRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando cadastro de cliente");

        var cliente = new Entities.Cliente
        {
            Nome = request.Nome,
            Telefone = request.Telefone.Replace(" ", ""),
            Email = request.Email,
            IdLocal = request.IdLocalVenda,
            DtNascimento = request.DataNascimento
        };

        _logger.LogInformation("Inserindo cliente no banco de dados");

        try
        {
            await _clienteRepository.CadastrarClienteAsync(cliente);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Ocorreu um erro ao cadastrar o cliente no banco de dados. Erro: {erro}", e.Message);
            return new CadastrarClienteException();
        }

        return new CadastrarClienteResponse(cliente.IdCliente);

    }
}