
using PokedexApi.Repositories;
using PokemonApi.Models;

namespace PokedexApi.Services;
public class HobbiesService : IHobbiesService
{
    private readonly IHobbiesRepository _hobbieRepository;

    public HobbiesService(IHobbiesRepository hobbieRepository)
    {
        _hobbieRepository = hobbieRepository;
    }

    public async Task<Hobbies?> GetHobbieById(int id, CancellationToken cancellationToken)
    {
        return await _hobbieRepository.GetHobbyByIdAsync(id, cancellationToken);
    }

    public async Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken)
    {
    var response = await _hobbieRepository.GetHobbiesByNameAsync(name, cancellationToken);
        return response?.ToList() ?? new List<Hobbies>();
    }
    
    public async Task<bool> DeleteHobbies(int id, CancellationToken cancellationToken)
    {
        return await _hobbieRepository.DeleteHobbies(id, cancellationToken);
    }
    
}
