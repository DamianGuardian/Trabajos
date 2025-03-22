
using PokedexApi.Dtos;
using PokemonApi.Models;


namespace PokedexApi.Mappers;

public static class PokemonMappers
{
    public static PokemonResponse ToDto(this Pokemon pokemon) {
        return new PokemonResponse {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Stats = new StatsResponse {
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                Speed = pokemon.Speed
            }
        };
    }
    public static Pokemon ToModel(this PokemonResponseDto pokemon) {
        return new Pokemon(
            pokemon.Id,
            pokemon.Name,
            pokemon.Type,
            pokemon.Level,
            pokemon.Stats.Attack,
            pokemon.Stats.Defense,
            pokemon.Stats.Speed
        );
    }
}