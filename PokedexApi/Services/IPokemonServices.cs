
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokemonApi.Models;

namespace PokedexApi.Services;

public interface IPokemonService
{
    public Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken);

    public Task<Pokemon?> GetPokemonByName(string name, CancellationToken cancellationToken);

    public Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken);

    Task UpdatePokemonAsync(Guid id, Pokemon pokemon, CancellationToken cancellationToken);
}