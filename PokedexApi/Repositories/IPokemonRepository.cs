
using PokemonApi.Models;

namespace PokedexApi.Repositories;

public interface IPokemonRepository
{
    Task GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);

    Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

}