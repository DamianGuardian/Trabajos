using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "UpdateHobbiesDto", Namespace = "http://pokemonapi/hobbies-service")]
public class UpdateHobbiesDto : HobbiesCommonDto {
    [DataMember(Name = "Id", Order = 0)]
    public  int Id { get; set; }
}