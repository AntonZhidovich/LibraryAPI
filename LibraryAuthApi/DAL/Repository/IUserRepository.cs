using LibraryAuthApi.DAL.Models;

namespace LibraryAuthApi.DAL.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUser(int id);
        Task<User?> GetUser(string username);
    }
}
