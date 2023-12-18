using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize);
        Task<Book> GetBookAsync(int id);
        Task<Book> GetBookAsync(string ISBN);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task SaveChangesAsync();
        int Count();
    }
}
