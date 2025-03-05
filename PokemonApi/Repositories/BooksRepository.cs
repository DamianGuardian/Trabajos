using PokemonApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;

namespace PokemonApi.Repositories;
    public class BooksRepository : IBooksRepository
    {
        private readonly RelationalDbContext _context;

        public BooksRepository(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<Books> GetBookByIdAsync(int id, CancellationToken cancellationToken)
        {
            var book = await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            return book.ToModel(); // Asumimos que hay un método ToModel() que convierte la entidad a modelo.
        }

    }