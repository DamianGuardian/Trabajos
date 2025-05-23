// Services/TrainerService.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PokedexApi.Models;
using PokedexApi.Repositories;

namespace PokedexApi.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repo;

        public TrainerService(ITrainerRepository repo)
            => _repo = repo;

        public Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
            => _repo.GetTrainerByIdAsync(id, cancellationToken);

        public IAsyncEnumerable<Trainer> GetTrainersByNameAsync(
            string name,
            CancellationToken cancellationToken)
            => _repo.GetTrainersByNameAsync(name, cancellationToken);
    }
}
