
using PokemonApi.Models;

namespace PokedexApi.Repositories;

public interface IHobbiesRepository
{
    // Método para obtener un hobby por su ID
    Task<Hobbies> GetHobbyBYIdAsync(int id, CancellationToken cancellationToken);
    Task <List<Hobbies>> GetHobbiesByNameAsync (string name, CancellationToken cancellationToken);
    
    // Método para eliminar un hobby por su ID
    Task<bool> DeleteHobbyByIdAsync(int id, CancellationToken cancellationToken);

}
