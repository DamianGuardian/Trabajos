using System.Runtime.Serialization;
using PokemonAPi.Dtos;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreatePokemonDto", Namespace = "http://pokemonapi/pokemon-service")]
public class CreatePokemonDto : PokemonCommomDto {
    
}