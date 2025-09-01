
namespace PokemonAPi.Exceptions
{
    public class PokemonValidationException : Exception
    {
        public PokemonValidationException(string message) : base(message)
        {
        }
    }
}