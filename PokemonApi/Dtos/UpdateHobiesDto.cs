using System.Runtime.Serialization;
using PokemonAPi.Dtos;
namespace PokemonApi.Dtos;

[DataContract(Name = "UpdatePokemonDto", Namespace = "http://pokemonapi/hobies-service")]

public class UpdateHobiesDto : HobiesCommomDto{
    [DataMember(Name = "Id", Order = 3)]
    public Guid Id { get; set; }

}
