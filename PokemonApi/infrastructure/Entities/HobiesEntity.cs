
namespace PokemonApi.Infrastructure.Entities;
public class HobiesEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Top { get; set; }

    internal object ToResponseDto()
    {
        throw new NotImplementedException();
    }
}