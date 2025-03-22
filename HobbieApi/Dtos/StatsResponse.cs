namespace PokedexApi.Dtos;

public class StatsResponse
{
     public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Top { get; set; }
    
}