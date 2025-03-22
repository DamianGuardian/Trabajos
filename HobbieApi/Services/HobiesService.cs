using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Models;
using PokemonApi.Mappers;

namespace PokemonAPi.Services;

public class HobbieService : IHobbieService
{
    private readonly IHobbiesRepository _hobbieRepository;

    public HobbieService(IHobbiesRepository hobbieRepository)
    {
        _hobbieRepository = hobbieRepository;
    }

    public async Task<HobiesResponseDto> GetHobbieById(Guid id, CancellationToken cancellationToken)
    {
        var hobie = await _hobbieRepository.GetHobbyByIdAsync(id, cancellationToken);
        if (hobie is null)
        {
            throw new FaultException("Hobie not found");
        }
        return hobie.ToDto();

    }


 


    public async Task<List<HobiesResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken)
    {

        // Llamar al repositorio para obtener los hobbies por nombre
        var hobbies = await _hobbieRepository.GetHobbiesByNameAsync(name, cancellationToken);

        // Si no hay hobbies encontrados, simplemente devuelve una lista vacía
        if (hobbies == null || !hobbies.Any())
        {
            return new List<HobiesResponseDto>();
        }

        // Retornar la lista de hobbies mapeada a DTOs
        
        return hobbies.Select(h => h.ToDto()).ToList();

        

    }





}

public interface IHobbiesRepository
{
    Task<IEnumerable<Hobbie>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken);
    Task<Hobbie> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);
}

public class Hobbie
{
    public HobiesResponseDto ToDto()
    {
        // Implement the mapping logic here
        return new HobiesResponseDto
        {
            Name = "Default Name" // Set the required Name property
        };
    }
}

[Serializable]
internal class FaultException : Exception
{
    public FaultException()
    {
    }

    public FaultException(string? message) : base(message)
    {
    }

    public FaultException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}