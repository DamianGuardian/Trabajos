using System.ServiceModel;
using PokemonAPi.Repositories;
using PokemonApi.Dtos;
using PokemonApi.Models;
using PokemonApi.Mappers;
using PokemonApi.Repositories;

namespace PokemonAPi.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _BooksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _BooksRepository = booksRepository;
    }


    public async Task<BooksResponseDto> GetBookById(int id, CancellationToken cancellationToken)
    {
        var book = await _BooksRepository.GetBookByIdAsync(id, cancellationToken);

        return book.ToDto();

    }

}