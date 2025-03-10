using System.Runtime.Serialization;
using PokemonApi.Dtos;

namespace PokemonApi.Dtos;

[DataContract(Name = "UpdateHobiesDto", Namespace = "http://PokemonApi/HobiesService")]
[KnownType(typeof(CreateHobiesDto))]
[KnownType(typeof(UpdateHobiesDto))]
public class HobiesCommomDto
{
    [DataMember(Name = "Name", Order = 1)]
    public string Name { get; set; }

    [DataMember(Name = "Top", Order = 2)]
    public int Top { get; set; }

}