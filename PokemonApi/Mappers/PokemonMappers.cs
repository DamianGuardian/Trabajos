using PokemonApi.Dtos;
using PokemonApi.Infrastructure;
using PokemonApi.Models;
namespace PokemonApi.Mapers;

public static class PokemonMapper
{
    public static Pokemon ToModel(this PokemonEntity pokemonEntity)
    {
        return new Pokemon
        {
            Id = pokemonEntity.Id,
            Name = pokemonEntity.Name,
            Type = pokemonEntity.Type,
            Level = pokemonEntity.Level,
            Stats = new Stats
            {
                Attack = pokemonEntity.Attack,
                Defense = pokemonEntity.Defense,
                Speed = pokemonEntity.Speed
            },
            SpecialAttack = pokemonEntity.SpecialAttack,
            SpecialDefense = pokemonEntity.SpecialDefense
        };
    }

    public static PokemonResponseDto ToDto(this Pokemon pokemon)
    {
        return new PokemonResponseDto
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Stats = new statsDto
            {
                Attack = pokemon.Stats.Attack,
                Defense = pokemon.Stats.Defense,
                Speed = pokemon.Stats.Speed
            },
            SpecialAttack = pokemon.SpecialAttack,
            SpecialDefense = pokemon.SpecialDefense
        };
    }
}