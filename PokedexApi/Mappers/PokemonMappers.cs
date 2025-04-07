
using PokedexApi.Dtos;
using PokemonApi.Dtos;
using PokemonApi.Models;
using PokemonAPi.Dtos;


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
    public static Pokemon ToModel(this CreatePokemonRequest pokemon) {
            return new Pokemon (
                id: Guid.NewGuid(), // or provide an appropriate id
                name : pokemon.Name,
                type : pokemon.Type,    
                level : pokemon.Level,
                attack : pokemon.Attack,
                defense : pokemon.Defense,
                speed : pokemon.Speed
            );
    }
    public static CreatePokemonDto ToSoapDto(this Pokemon pokemon) 
    {
        return new CreatePokemonDto {
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Stats = new StatsDto {
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                Speed = pokemon.Speed
        }
    };
}

public static Pokemon ToModel(this UpdatePokemonRequest pokemon) {
    return new Pokemon(
        id: Guid.NewGuid(), // or provide an appropriate id
        name: pokemon.Name,
        type: pokemon.Type,
        level: pokemon.Level,
        attack: pokemon.Attack,
        defense: pokemon.Defense,
        speed: pokemon.Speed
    );
}

public static UpdatePokemonDto ToUpdateSoapDto(this Pokemon pokemon) {
    return new UpdatePokemonDto {
        Id = pokemon.Id,
        Name = pokemon.Name,
        Type = pokemon.Type,
        Level = pokemon.Level,
        Stats = new StatsDto {
            Attack = pokemon.Attack,
            Defense = pokemon.Defense,
            Speed = pokemon.Speed
        }
    };
}
}