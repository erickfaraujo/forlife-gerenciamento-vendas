using ForlifeGerenciamentoVendas.API.Extensions;
using ForlifeGerenciamentoVendas.Shareable.Requests.LocaisVenda;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForlifeGerenciamentoVendas.API.Endpoints;

public static class LocalVendaEndpoints
{
    public static void MapLocalVendaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/locais/", ConsultarLocais);
        app.MapGet("/v1/locais/{id}", ConsultarDetalhesLocal);
        app.MapPost("/v1/locais/", CadastrarLocal);
    }

    public static async Task<IResult> ConsultarLocais([FromServices] IMediator m, [FromQuery] string? descricao)
        => await m.SendCommand(new ConsultarLocaisRequest(descricao));

    public static async Task<IResult> ConsultarDetalhesLocal([FromServices] IMediator m, [FromQuery] string id)
        => await m.SendCommand(new ConsultarDetalhesLocalRequest(id));

    private static async Task<IResult> CadastrarLocal([FromServices] IMediator m, [FromBody] CadastrarLocalRequest request)
        => await m.SendCommand(request);
}
