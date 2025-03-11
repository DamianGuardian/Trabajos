

namespace PokedexApi.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }

    public required string Type { get; set; }

    public int level { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }


}