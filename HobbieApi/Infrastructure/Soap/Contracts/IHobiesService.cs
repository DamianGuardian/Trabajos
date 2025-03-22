using System.ServiceModel;
using PokemonApi.Dtos;
using System.Runtime.Serialization;

namespace HobiesApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name = "DamianHobbiesService", Namespace = "http://hobbie-api/hobbie-service")]
public interface IHobbieService
{
    [OperationContract]
    Task<HobiesResponseDto> GetHobbieById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeleteHobbieById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<List<HobiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken);

    [OperationContract]
    Task<HobiesResponseDto> CreateHobbie(CreateHobiesDto createHobiesDto, CancellationToken cancellationToken);

    [OperationContract]
    Task<HobiesResponseDto> UpdateHobbie(UpdateHobiesDto hobbieDto, CancellationToken cancellationToken);

}

internal class OperationContractAttribute : Attribute
{
}

internal class ServiceContractAttribute : Attribute
{
    public required string Name { get; set; }
    public required string Namespace { get; set; }
}