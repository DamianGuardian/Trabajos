using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Services;
using SoapCore;
using PokemonApi.Repositories;
using PokemonAPi.Repositories;
using PokemonAPi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
//host.docker.internal
//AddSingleton
builder.Services.AddSingleton<IPokemonService,PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddSingleton<IHobbiesRespository, HobbiesRepository>();
builder.Services.AddScoped<IHobbieService, HobbieService>();
builder.Services.AddSingleton<IBooksRepository, BooksRepository>();
builder.Services.AddScoped<IBookService, BookService>();



builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbieService>("/HobbieService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IBookService>("/BooksService.svc", new SoapEncoderOptions());


app.Run();