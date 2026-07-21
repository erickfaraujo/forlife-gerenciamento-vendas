//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;

//namespace ForlifeGerenciamentoVendas.Domain.Handlers.sust;

//public class SustRequestHandler : IRequestHandler<SustRequest, Result<SustResponse>>
//{
//    private readonly IForlifeVendasRepository _forlifeVendasRepository;
//    private readonly ILogger<SustRequestHandler> _logger;

//    public SustRequestHandler(IForlifeVendasRepository forlifeVendasRepository, ILogger<SustRequestHandler> logger)
//    {
//        _forlifeVendasRepository = forlifeVendasRepository;
//        _logger = logger;
//    }


//    public async Task<Result<SustResponse>> Handle(SustRequest request, CancellationToken cancellationToken)
//    {
//        //consultar lista de todos os pedidos
//        _logger.LogInformation("Iniciando consulta de pedidos");
//        var listaPedidos = _forlifeVendasRepository.GetPedidosAsync(new(default, default, default, default));

//        _logger.LogInformation("Encontadro {pedidos} pedidos", listaPedidos.Result!.Count());

//        var cont = 1;

//        //percorrer lista com cada pedido
//        foreach (var pedido in listaPedidos.Result!)
//        {
//            //verificar se o infoAdicionas.Telefone está null
//            if (pedido.InfosAdicionais.Telefone is null)
//            {
//                //consultar o cliente daquele pedido
//                var cliente = await _forlifeVendasRepository.GetAsync<Cliente>(pedido.Pk, "PERFIL");
//                var aux = new InfosAdicionais(pedido.InfosAdicionais.NomeCliente, pedido.InfosAdicionais.NomeLocal, cliente!.Telefone);
//                //atribuir infoAdicionas.Telefone = cliente.Telefone
//                pedido.InfosAdicionais = aux;

//                var insert = await _forlifeVendasRepository.CreateAsync(pedido);
//                _logger.LogInformation("resultado insert {num}: {result}", cont, insert);
//                cont++;
//            }
//        }

//        _logger.LogInformation("finalizado");

//        return new SustResponse();
//    }
//}
