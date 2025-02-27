using System;
using System.Threading;
using System.Threading.Tasks;
using PokemonApi.Models;

namespace PokemonApi.Repositories
{
    public interface IBooksRepository
    {
        Task<Books> GetBookByIdAsync(int id, CancellationToken cancellationToken);
    }
}
