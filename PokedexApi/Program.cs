using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Repositories;
using PokedexApi.Services;

//localhost:5281/swagger

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IHobbiesService, HobbiesService>();
builder.Services.AddScoped<IHobbiesRepository, HobbiesRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainerService, PokedexApi.Services.TrainerService>();

builder.Services.AddSingleton(s =>
{
    var channel = GrpcChannel.ForAddress(builder.Configuration.GetValue<string>("TrainersApiUrl"));
        
    return new PokedexApi.Infrastructure.Grpc.TrainerService.TrainerServiceClient(channel);
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration.GetValue<string>("Authentication:Authority");
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = "pokedex-api",
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(name: "Read", configurePolicy: policy =>
        policy.RequireClaim("http://schemas.microsoft.com/identity/claims/scope", "read"));

    options.AddPolicy(name: "Write", configurePolicy: policy =>
        policy.RequireClaim("http://schemas.microsoft.com/identity/claims/scope", "write"));
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();