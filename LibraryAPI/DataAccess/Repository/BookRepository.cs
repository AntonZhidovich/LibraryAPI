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

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _dbContext.Books.OrderBy(b => b.DateOfReturn).ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            Book? book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogError("Book with ID {id} was not found.", id);
                throw new ArgumentException("Book with such ID not found.");
            }

            return book;
        }

        public async Task<Book> GetBook(string ISBN)
        {
            Book? book = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == ISBN);
            if (book == null)
            {
                _logger.LogError("Book with ISBN {ISBN} was not found.", ISBN);
                throw new ArgumentException("Book with such ISBN not found.");
            }

            return book;
        }

        public async Task CreateBook(Book book)
        {
            await _dbContext.AddAsync(book);
            await SaveChanges();
        }

        public async Task UpdateBook(Book book)
        {
            _dbContext.Update(book);
            await SaveChanges();
        }

        public async Task DeleteBook(Book book)
        {
            _dbContext.Remove(book); 
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
