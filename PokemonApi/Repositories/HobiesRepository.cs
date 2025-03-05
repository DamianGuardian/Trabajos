using PokemonApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;

namespace PokemonAPi.Repositories;

public class HobbiesRepository : IHobbiesRespository
{
    private readonly RelationalDbContext _context;

    public HobbiesRepository(RelationalDbContext context)
    {
        _context = context;
    }

    public async Task<Hobies> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var hobies = await _context.Hobies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return hobies.ToModel();
    }

    //Delete hobies by id
    public async Task DeleteHobbyAsync(Hobies hobies, CancellationToken cancellationToken)
    {
        _context.Hobies.Remove(hobies.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);

    }

    //Get hobies by name
    public async Task<List<Hobies>> GetHobbiesByNameAsync(string name, CancellationToken cancellationToken)
    {
        var hobbie = await _context.Hobies.AsNoTracking().Where(s => s.Name.Contains(name)).ToListAsync(cancellationToken);
        return hobbie.Select(h => h.ToModel()).ToList();
    }

    //Update hobies

  public async Task AddAsync(Hobies hobbie, CancellationToken cancellationToken) 
{
    await _context.Hobies.AddAsync(hobbie.ToEntity(), cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
}

public async Task UpdateAsync(Hobies hobbie, CancellationToken cancellationToken) 
{
    _context.Hobies.Update(hobbie.ToEntity());
    await _context.SaveChangesAsync(cancellationToken);
}

public async Task<IEnumerable<Hobies>> GetAllAsync(CancellationToken cancellationToken)
{
    var hobies = await _context.Hobies.AsNoTracking().ToListAsync(cancellationToken);
    return hobies.Select(h => h.ToModel());
}
}