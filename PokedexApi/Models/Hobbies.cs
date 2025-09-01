
using static System.Reflection.Metadata.BlobBuilder;

namespace PokemonApi.Models;
    public class Hobbies
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Top { get; set; }

    internal static Blobs ToModel()
    {
        throw new NotImplementedException();
    }
}

internal class RelationalDbContext
{
    public required object Hobbies { get; internal set; }

    internal void SaveChanges(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}