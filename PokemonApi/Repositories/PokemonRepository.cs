using Microsoft.EntityFrameworkCore;
using PokemonApi.Models;
using PokemonApi.Infrastructure;
using PokemonApi.Mapers;
namespace PokemonApi.Repositories;

public class PokemonRepository : IPokemonRepository
{

    private readonly RelationlDbContext _context;

    public PokemonRepository(RelationlDbContext context)
    {
        _context = context;
    }

    public async Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken) {
        var pokemon = await _context.Pokemons.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return pokemon.ToModel();
    }
}
