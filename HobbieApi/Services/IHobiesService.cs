using System.ServiceModel;
using PokemonApi.Dtos;


public interface IHobbieService
{
    
    Task<HobiesResponseDto> GetHobbieById(Guid id, CancellationToken cancellationToken);
   
    Task<List<HobiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken);
}