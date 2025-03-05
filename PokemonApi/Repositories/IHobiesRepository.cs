using PokemonApi.Models;
namespace PokemonAPi.Repositories;


public interface IHobbiesRespository{

    Task<Hobies> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteHobbyAsync(Hobies hobies, CancellationToken cancellationToken);

    Task<List<Hobies>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken);

    Task AddAsync(Hobies hobbie, CancellationToken cancellationToken);

Task UpdateAsync(Hobies hobbie, CancellationToken cancellationToken);

 Task<IEnumerable<Hobies>> GetAllAsync(CancellationToken cancellationToken); // Added method

}