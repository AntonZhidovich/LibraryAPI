using LibraryAPI.DAL.Data;
using LibraryAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> _logger;
        public readonly BookDBContext _dbContext;

        public BookRepository(ILogger<BookRepository> logger, BookDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize)
        {
            return await _dbContext.Books
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(b => b.DateOfReturn)
                .ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            return book;
        }

        public async Task<Book?> GetBookAsync(string ISBN)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == ISBN);
            return book;
        }

        public async Task CreateBookAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            await SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _dbContext.Update(book);
            await SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _dbContext.Remove(book); 
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public int Count()
        {
            return _dbContext.Books.Count();
        }
    }
}
