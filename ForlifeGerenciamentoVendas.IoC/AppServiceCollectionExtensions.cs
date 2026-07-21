using ForlifeGerenciamentoVendas.Data;
using ForlifeGerenciamentoVendas.Data.Repositories;
using ForlifeGerenciamentoVendas.Domain.Handlers.LocaisVenda;
using ForlifeGerenciamentoVendas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForlifeGerenciamentoVendas.IoC;

public static class AppServiceCollectionExtensions
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CadastrarLocalRequestHandler).Assembly);
        });

        services.AddDbContext<ForlifeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ForlifeDatabase")));

        services.AddScoped<ILocalVendaRepository, LocalVendaRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
    }
}
