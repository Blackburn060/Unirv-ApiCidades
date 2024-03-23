using Atividade04.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<LocalizacaoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cidades", (LocalizacaoService service, string stateCode, string countryCode) => 
    service.GetCidades(stateCode, countryCode))
   .WithName("GetCidades");

app.MapGet("/estados", (LocalizacaoService service, string countryCode) => 
    service.GetEstados(countryCode))
   .WithName("GetEstados");

app.MapGet("/paises", (LocalizacaoService service) => 
    service.GetPaises())
   .WithName("GetPaises");

app.MapGet("/cidade", (LocalizacaoService service, string citieName) => 
    service.GetCidadesPorNome(citieName))
   .WithName("GetCidadePorNome");

app.Run();