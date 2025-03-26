using PokedexApi.Infrastructure.Soap.Contracts;
using System.ServiceModel;
using PokedexApi.Mappers;
using PokemonApi.Models;
using PokemonAPi.Exceptions;
using PokedexApi.Exceptions;

namespace PokedexApi.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokemonService;

    public PokemonRepository(ILogger<PokemonRepository> logger, IConfiguration configuration) {
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _pokemonService = new ChannelFactory<IPokemonService>(binding, endpoint).CreateChannel();
    }

    public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken) {
        try {
            var pokemon = await _pokemonService.GetPokemonById(id, cancellationToken);
            return pokemon.ToModel();
        } 
        catch (FaultException ex) when(ex.Message=="Pokemon not found :(")
        {
            _logger.LogWarning(ex, "Failed to get pokemon with id {id}", id);
            return null;
        }
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken) {
        try {
            var pokemon = await _pokemonService.GetPokemonByName(name, cancellationToken);
            return pokemon.ToModel();
        } 
        catch (FaultException ex) when(ex.Message=="Pokemon not found :(")
        {
            _logger.LogWarning(ex, "Failed to get pokemon with name {name}", name);
            return null;
        }
    }

    public async Task GetByNameAsync(string name, CancellationToken cancellationToken) {
        await _pokemonService.GetByName(name, cancellationToken);
    }
    
    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken) {
       
       {
try{
    await _pokemonService.DeletePokemon(id, cancellationToken);
    return true;
}
catch (FaultException ex) when(ex.Message=="Pokemon not found :(")

{return false;}
catch (FaultException ex) 
{
   _logger.LogError(ex, "Failed to delete pokemon with id {id}", id);
    throw; 
}


}

       }
    
public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
{
    try
    {
        
        var PokemonCreated = await _pokemonService.CreatePokemon(pokemon.ToSoapDto(), cancellationToken);
        return PokemonCreated.ToModel();
    }
    
    catch (FaultException ex) when (ex.Message.Contains("Pokemon"))
    {
        throw new PokemonValidationException(ex.Message);
    }
    catch (FaultException ex)
    {
        _logger.LogError(ex, "Error creating pokemon");
        throw;
    }
}
}
