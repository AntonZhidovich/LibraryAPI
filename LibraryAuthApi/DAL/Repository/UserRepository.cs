using LibraryAuthApi.BLL.Data;
using LibraryAuthApi.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthApi.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext _dBContext;

        public UserRepository(UserDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _dBContext.Users.FindAsync(id);
        }

        public async Task<User?> GetUser(string username)
        {
			return await _dBContext.Users.FirstOrDefaultAsync(u => u.UserName  == username);
		}
    }
}
