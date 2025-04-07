
using System.ServiceModel;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Exceptions;
using PokedexApi.Mappers;
using PokedexApi.Repositories;
using PokemonApi.Models;
using PokemonAPi.Exceptions;

namespace PokedexApi.Services;

public class PokemonService : IPokemonService {

    private readonly IPokemonRepository _pokemonRepository;

    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    public async Task<Pokemon?> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        
        var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);
        
        return pokemon;
    }


    public async Task<Pokemon?> GetPokemonByName(string name, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
    }

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);
    }

     public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(pokemon.Name) || string.IsNullOrWhiteSpace(pokemon.Type))
    {
        throw new PokemonValidationException("El nombre y el tipo del Pokémon son obligatorios.");
    }

    if (pokemon.Level < 1 || pokemon.Level > 100)
    {
        throw new PokemonValidationException("El nivel debe estar entre 1 y 100.");
    }

    if (pokemon.Attack <= 0 || pokemon.Defense <= 0 || pokemon.Speed <= 0)
    {
        throw new PokemonValidationException("Los valores de ataque, defensa y velocidad deben ser mayores que 0.");
    }

    return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken);
}

public async Task UpdatePokemonAsync(Guid id, Pokemon pokemon, CancellationToken cancellationToken)
{
    var existingPokemon = await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);
    if (existingPokemon == null)
    {
        throw new PokemonNotFoundException(); // 404 - Not Found
    }

    var conflictingPokemon = await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name, cancellationToken);
    if (conflictingPokemon != null && conflictingPokemon.Id != id)
    {
        throw new PokemonAlreadyExistsException(); // 409 - Conflict
    }

    if (pokemon.Level <= 0)
    {
        throw new PokemonValidationException("Level must be greater than 0"); // 400 - Bad Request
    }

    pokemon.Id = id;
    await _pokemonRepository.UpdatePokemonAsync(id, pokemon, cancellationToken);
}
}