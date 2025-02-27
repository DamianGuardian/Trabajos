using PokemonApi.Models;
namespace PokemonAPi.Repositories;


public interface IHobbiesRespository
{

    Task<Hobies> GetHobbyByIdAsync(int id, CancellationToken cancellationToken);

    Task DeleteHobbyAsync(Hobies hobies, CancellationToken cancellationToken);

    Task<List<Hobies>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken);

}