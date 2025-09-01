using PokemonApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace PokemonApi.Models;

public class Hobies
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Top { get; set; }
    
    
    public HobiesModel ToModel()
    {
        return new HobiesModel
        {
            Id = this.Id,
            Name = this.Name,
            Top = this.Top
        };
    }
}

public class HobiesModel
{
    public Guid Id { get; internal set; }
    public string? Name { get; internal set; }
    public int Top { get; internal set; }
}

public class RelationalDbContext
{
    public DbSet<Hobies>? Hobies { get; internal set; }

    
}


