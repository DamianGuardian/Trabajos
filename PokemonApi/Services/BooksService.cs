using System;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Services
{
    public class BookService : IBookService
    {
        private readonly DbContext _context;  // Usamos DbContext directamente si no tienes un contexto específico.

        public BookService(DbContext context)  // Constructor que acepta DbContext directamente.
        {
            _context = context;
        }

        public async Task<BooksResponseDto> GetBookById(int id, CancellationToken cancellationToken)
        {
            // Asumimos que la entidad `Books` está correctamente configurada en DbContext
            var book = await _context.Set<Books>()  // Usamos Set<Books>() para obtener la DbSet de libros.
                .Where(b => b.Id == id)
                .Select(b => new BooksResponseDto(
                    b.Id,
                    b.Title,
                    b.Author,
                    b.PublishedDate
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (book == null)
            {
                // Utilizamos FaultException directamente con un solo argumento de tipo string.
                throw new FaultException("Book not found.");
            }

            return book;
        }
    }
}