using ForlifeGerenciamentoVendas.Shareable.Exceptions;
using ForlifeGerenciamentoVendas.Shareable.Responses;
using MediatR;
using OperationResult;
using System.Net;

namespace ForlifeGerenciamentoVendas.API.Extensions;

public static class Extensions
{
    public static async Task<IResult> SendCommand<T>(this IMediator mediator, IRequest<Result<T>> request, Func<T, IResult>? result = null)
        => await mediator.Send(request) switch
        {
            (true, var response, _) => result != null ? result(response!) : Results.Ok(response),
            var (_, _, error) => HandleError(error!)
        };


    //TODO: Ajustas as exceptions para o projeto, e tratar elas aqui
    private static IResult HandleError(Exception error)
        => error switch
        {
            CadastrarClienteException e => new StatusCodeResult<ErroResponse>((int)HttpStatusCode.InternalServerError, new ErroResponse(e.Mensagem)),
            ClienteNaoLocalizadoException => Results.StatusCode(404),
            //CadastrarLocalException e => new ObjectResult(e.Mensagem) { StatusCode = 500 },
            LocalNaoLocalizadoException => Results.StatusCode(404),
            //PedidoNaoLocalizadoException e => new NotFoundObjectResult(e.Mensagem),
            //AtualizarClienteException e => new ObjectResult(e.Mensagem) { StatusCode = 500 },
            //ExcluirClienteException e => new ObjectResult(e.Mensagem) { StatusCode = 500 },
            //ExcluirClienteComPedidoException e => new BadRequestObjectResult(e.Mensagem),
            _ => Results.StatusCode(500)
        };

    private readonly struct StatusCodeResult<T>(int StatusCode, T? Value) : IResult
    {
        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCode;
            return Value is null
                 ? Task.CompletedTask
                 : httpContext.Response.WriteAsJsonAsync(Value, Value.GetType(), options: null, contentType: "application/json");
        }
    }
}
