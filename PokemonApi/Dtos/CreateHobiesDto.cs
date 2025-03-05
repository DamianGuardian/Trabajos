using System.Runtime.Serialization;
using PokemonAPi.Dtos;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreateHobiesDto", Namespace = "http://pokemonapi/hobies-service")]
public class CreateHobiesDto : HobiesCommomDto{
    
    
}
