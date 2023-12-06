using LibraryAuthApi.DAL.Models;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;

namespace LibraryAuthApi.BLL.Services
{
    public class SignInService : ISignInService
    {
		private readonly ILogger<SignInService> _logger;
		private readonly IUserRepository _repository;
		private readonly ITokenBuilder _tokenBuilder;

		public SignInService(
			ILogger<SignInService> logger,
			IUserRepository repository, 
			ITokenBuilder tokenBuilder)
        {
			this._logger = logger;
			_repository = repository;
			_tokenBuilder = tokenBuilder;
		}

        public async Task<string> SignIn(UserLoginDTO userLogin)
        {
			User? user = await _repository.GetUser(userLogin.UserName.Trim());
			if (user == null)
			{
				_logger.LogError("The user with username: \"{username}\" was not found.", userLogin.UserName);
				throw new ArgumentException("The user was not found.");
			}

			if(user.Password != userLogin.Password)
			{
				_logger.LogError("Ivalid password:  \"{password}\"", userLogin.Password);
				throw new ArgumentException("Ivalid password.");
			}

			string token = _tokenBuilder.BuildToken(user);
			return token;
		}
    }
}
