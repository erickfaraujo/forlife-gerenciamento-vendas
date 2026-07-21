using ForlifeGerenciamentoVendas.API.Endpoints;
using ForlifeGerenciamentoVendas.IoC;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureAppDependencies(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ForlifeVendas", Version = "v1" });
});

var app = builder.Build();

app.MapOpenApi();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "ForlifeVendas v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapLocalVendaEndpoints();
app.MapClienteEndpoints();

app.Run();
