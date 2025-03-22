using System.Runtime.Serialization;
using HobbieApi.Controllers;
using PokedexApi.Repositories;

namespace PokemonApi.Dtos;

[DataContract(Name = "HobiesResponseDto", Namespace = "http://pokemonapi/Hobies-service")]
public class HobiesResponseDto
{
    [DataMember(Name = "Id", Order = 1)]
    public Guid Id { get; set; }

    [DataMember(Name = "Name", Order = 2)]
    public required string Name { get; set; }

    [DataMember(Name = "Top", Order = 3)]
    public int Top { get; set; }

    internal IHobbyRepository? ToModel()
    {
        throw new NotImplementedException();
    }
}

public static class HobiesResponseDtoExtensions
    {
        public static HobbyResponse ToDto(this HobiesResponseDto hobbyResponseDto)
        {
            return new HobbyResponse
            {
                // Map properties from hobbyResponseDto to HobbyResponse
            };
        }
    }

public class HobbyResponse
{
}

