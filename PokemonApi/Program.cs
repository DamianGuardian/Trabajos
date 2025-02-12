using PokemonApi.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

builder.Services.AddScoped<IPokemonService, PokemonService>();

var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());

app.Run();