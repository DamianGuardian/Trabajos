using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "PokemonDto", Namespace = "http://pokemonapi/pokemon-service")]
public class CreatePokemonDto
{
    [DataMember(Name = "Name", Order = 1)]
    public string Name { get; set; }

    [DataMember(Name = "Type", Order = 2)]
    public string Type { get; set; }

    [DataMember(Name = "Level", Order = 3)]
    public int Level { get; set; }

    [DataMember(Name = "SpecialAttack", Order = 4)]
    public int SpecialAttack { get; set; }

    [DataMember(Name = "SpecialDefense", Order = 5)]
    public int SpecialDefense { get; set; }

    [DataMember(Name = "Attack", Order = 6)]
    public int Attack { get; set; }

    [DataMember(Name = "Defense", Order = 7)]
    public int Defense { get; set; }
}
