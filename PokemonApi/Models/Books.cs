using PokemonApi.Dtos;

namespace PokemonApi.Models;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }

    public BooksResponseDto ToDto()
    {
        return new BooksResponseDto
        {
            Id = Id,
            Title = Title,
            Author = Author,
            PublishedDate = PublishedDate
        };
    }
    
}