using PokedexApi.Dtos;
using PokedexApi.Models;
namespace static class PokemonMapper
{
    public static PokemonResponse MapToPokemonResponse(Pokemon pokemon)
    {
        return new PokemonResponse
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Stats = new StatsResponse
            {
                Attack = pokemon.Attack,
                Defense = pokemon.Defense
                Speed = pokemon.Speed
            }
        };
    }
    
   
}