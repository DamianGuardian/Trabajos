using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "BooksResponseDto", Namespace = "http://pokemonapi/books-service")]
public class BooksResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }

    public BooksResponseDto(int id, string title, string author, DateTime publishedDate)
    {
        Id = id;
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }


}