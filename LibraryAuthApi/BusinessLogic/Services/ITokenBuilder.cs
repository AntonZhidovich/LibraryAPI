using LibraryAuthApi.DAL.Models;

namespace LibraryAuthApi.DAL.Services
{
    public interface ITokenBuilder
    {
        string BuildToken(User user);
    }
}
