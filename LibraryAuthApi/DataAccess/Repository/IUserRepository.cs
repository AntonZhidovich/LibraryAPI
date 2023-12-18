using LibraryAuthApi.DAL.Models;

namespace LibraryAuthApi.DAL.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string username);
    }
}
