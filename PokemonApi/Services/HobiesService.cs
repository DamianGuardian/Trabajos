using System.ServiceModel;
using PokemonAPi.Repositories;
using PokemonApi.Dtos;
using PokemonApi.Models;
using PokemonApi.Mappers;

namespace PokemonAPi.Services;

public class HobbieService : IHobbieService
{
    private readonly IHobbiesRespository _hobbieRepository;

    public HobbieService(IHobbiesRespository hobbieRepository)
    {
        _hobbieRepository = hobbieRepository;
    }

    public async Task<HobiesResponseDto> GetHobbieById(int id, CancellationToken cancellationToken)
    {
        var hobie = await _hobbieRepository.GetHobbyByIdAsync(id, cancellationToken);
        if (hobie is null)
        {
            throw new FaultException("Hobie not found");
        }
        return hobie.ToDto();

    }


    public async Task<bool> DeleteHobbieById(int id, CancellationToken cancellationToken)
    {
        var hobbie = await _hobbieRepository.GetHobbyByIdAsync(id, cancellationToken);
        if (hobbie is null)
        {
            throw new FaultException("Hobie not found");
        }
        await _hobbieRepository.DeleteHobbyAsync(hobbie, cancellationToken);
        return true;
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