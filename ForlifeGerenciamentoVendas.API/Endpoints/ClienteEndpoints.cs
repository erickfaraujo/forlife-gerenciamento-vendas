using ForlifeGerenciamentoVendas.API.Extensions;
using ForlifeGerenciamentoVendas.Shareable.Requests.Cliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForlifeGerenciamentoVendas.API.Endpoints;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/clientes", CadastrarCliente)
            .WithName("CadastrarCliente");
        app.MapGet("/v1/clientes", ConsultarClientes)
            .WithName("ConsultarClientes");
        app.MapGet("/v1/clientes/{id:int}", ConsultarDetalhesCLiente)
            .WithName("CadastrarDetalhesCliente");
        app.MapPut("/v1/clientes/{id:int}", AtualizarCliente)
            .WithName("AtualizarCliente");
    }

    private static async Task<IResult> CadastrarCliente([FromServices] IMediator m, [FromBody] CadastrarClienteRequest request)
        => await m.SendCommand(request);

    private static async Task<IResult> ConsultarClientes([FromServices] IMediator m, [FromQuery] int? Id, Guid? IdLocal, string? Nome, string? Telefone)
        => await m.SendCommand(new ConsultarClientesRequest(Id, IdLocal, Nome, Telefone));

    private static async Task<IResult> ConsultarDetalhesCLiente([FromServices] IMediator m, [FromRoute] int id)
        => await m.SendCommand(new ConsultarDetalhesClienteRequest(id));

    private static async Task<IResult> AtualizarCliente([FromServices] IMediator m, [FromQuery] int id, [FromBody] AtualizarClienteRequest request)
        => await m.SendCommand(request with { Id = id });

}