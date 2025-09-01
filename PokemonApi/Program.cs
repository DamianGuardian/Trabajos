using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using SoapCore;
using PokemonApi.Repositories;
using PokemonAPi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();

// Cambiar a Scoped
builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddSingleton<IHobbiesRepository, HobbiesRepository>();
builder.Services.AddScoped<IHobbiesService, HobiesService>();
builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBooksService, BooksService>();

// Configurar DbContext
builder.Services.AddDbContext<RelationalDbContext>(options => 
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

// Configurar endpoints de SOAP
app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbiesService>("/HobbieService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IBooksService>("/BooksService.svc", new SoapEncoderOptions());

app.Run();
