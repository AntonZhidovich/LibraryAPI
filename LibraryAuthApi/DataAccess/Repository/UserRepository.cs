using LibraryAuthApi.BLL.Data;
using LibraryAuthApi.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAuthApi.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
		private readonly ILogger<UserDBContext> _logger;
		private readonly UserDBContext _dBContext;

        public UserRepository(ILogger<UserDBContext> logger,  UserDBContext dBContext)
        {
			_logger = logger;
			_dBContext = dBContext;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dBContext.Users.FindAsync(id);
			if (user == null)
			{
				_logger.LogError("The user with id: \"{id}\" was not found.", id);
				throw new ArgumentException("The user was not found.");
			}

            return user;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _dBContext.Users.FirstOrDefaultAsync(u =>
			u.UserName.ToLower() == username.ToLower());
			if (user == null)
			{
				_logger.LogError("The user with username: \"{username}\" was not found.", username);
				throw new ArgumentException("The user was not found.");
			}

			return user;
		}
    }
}
