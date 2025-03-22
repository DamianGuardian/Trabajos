

namespace PokedexApi.Repositories;

public interface IHobbyRepository
{
    Task<IHobbyRepository?> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<IHobbyRepository>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken);
}