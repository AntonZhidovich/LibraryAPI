using LibraryAPI.DAL.Models;

namespace LibraryAPI.DAL.Repository
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> GetBooks();
		Task<Book?> GetBook(int id);
		Task<Book?> GetBook(string ISBN);
		Task CreateBook(Book book);
		Task UpdateBook(Book book);
		Task DeleteBook(Book book);
	}
}
