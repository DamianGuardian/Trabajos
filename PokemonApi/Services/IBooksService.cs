using System.ServiceModel;
using PokemonApi.Dtos;

[ServiceContract(Name = "DamianBooksService", Namespace = "http://pokemonapi/books-service")]
public interface IBooksService
{
    [OperationContract]
    Task<BooksResponseDto> GetBookById(int id, CancellationToken cancellationToken);


}