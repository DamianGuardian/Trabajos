using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "HobiesResponseDto", Namespace = "http://pokemonapi/Hobies-service")]
public class HobiesResponseDto
{
    [DataMember(Name = "Id", Order = 1)]
    public int Id { get; set; }

    [DataMember(Name = "Name", Order = 2)]
    public string Name { get; set; }

    [DataMember(Name = "Top", Order = 3)]
    public int Top { get; set; }
    
}