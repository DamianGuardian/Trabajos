using System.Runtime.Serialization;
using PokemonAPi.Dtos;



namespace PokemonApi.Dtos;



[DataContract(Name = "UpdatePokemonDto", Namespace = "http://pokemonapi/pokemon-service")]

public class UpdatePokemonDto : PokemonCommomDto{
    [DataMember(Name = "Id", Order = 5)]
    public Guid Id { get; set; }

}