using System.ServiceModel;
using PokemonApi.Dtos;

[ServiceContract(Name = "DamianHobbiesService", Namespace = "http://hobbie-api/hobbie-service")]
public interface IHobbieService
{
    [OperationContract]
    Task<HobiesResponseDto> GetHobbieById(int id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeleteHobbieById(int id, CancellationToken cancellationToken);

    [OperationContract]
    Task<List<HobiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken);

}