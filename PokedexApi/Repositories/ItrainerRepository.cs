using System.Threading;
using System.Threading.Tasks;
using PokedexApi.Models;

namespace PokedexApi.Repositories
{
    public interface ITrainerRepository
    {
        Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken);
        IAsyncEnumerable<Trainer> GetTrainersByNameAsync(string name, CancellationToken cancellationToken);
        Task<(int SuccessCount, List<Trainer> CreatedTrainers)> CreateTrainerAsync(List<Trainer> trainers, CancellationToken cancellationToken);
    }
}