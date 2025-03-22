
using PokedexApi.Dtos;
using PokemonApi.Models;

namespace PokedexApi.Services;

public interface IPokemonService
{
    public Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken);

    public Task<Pokemon?> GetPokemonByName(string name, CancellationToken cancellationToken);

    public Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    
}