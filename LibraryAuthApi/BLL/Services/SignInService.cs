using LibraryAuthApi.DAL.Models;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;

namespace LibraryAuthApi.BLL.Services
{
    public class SignInService : ISignInService
    {
		private readonly IUserRepository _repository;
		private readonly ITokenBuilder _tokenBuilder;

		public SignInService(IUserRepository repository, ITokenBuilder tokenBuilder)
        {
			_repository = repository;
			_tokenBuilder = tokenBuilder;
		}

        public async Task<string> SignIn(UserLoginDTO userLogin)
        {
			User? user = await _repository.GetUser(userLogin.UserName);
			if (user == null || userLogin.Password != user.Password)
			{
				throw new ArgumentException("Invalid username or password.");
			}

			string token = _tokenBuilder.BuildToken(user);
			return token;
		}
    }
}
