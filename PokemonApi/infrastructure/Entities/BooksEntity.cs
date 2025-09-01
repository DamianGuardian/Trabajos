namespace PokemonApi.Infrastructure.Entities;
using System;

public class BooksEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
}