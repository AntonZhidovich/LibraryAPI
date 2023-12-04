using LibraryAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repository
{
	public class BookRepository : IBookRepository
	{
		 public readonly BookDBContext _dbContext;

        public BookRepository(BookDBContext dBContext)
        {
            _dbContext = dBContext;
        }

		public async Task<IEnumerable<Book>> GetBooks()
		{
			return await _dbContext.Books.OrderBy(b => b.DateOfReturn).ToListAsync();
		}

		public async Task<Book?> GetBook(int id)
		{
			return await _dbContext.Books.FindAsync(id);
		}

		public async Task<Book?> GetBook(string ISBN)
		{
			return await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == ISBN);
		}

		public async Task CreateBook(Book book)
		{
			await _dbContext.AddAsync(book);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateBook(Book book)
		{
			_dbContext.Update(book);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteBook(Book book)
		{
			_dbContext.Remove(book); 
			await _dbContext.SaveChangesAsync();
		}
	}
}
