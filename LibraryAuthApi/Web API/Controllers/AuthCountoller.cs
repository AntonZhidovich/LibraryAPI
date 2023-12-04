using LibraryAuthApi.BLL.Models;
using LibraryAuthApi.DAL.Models;
using LibraryAuthApi.DAL.Repository;
using LibraryAuthApi.DAL.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAuthApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthCountoller : Controller
	{
		private readonly ITokenBuilder _tokenBuilder;
		private readonly IUserRepository _repository;

		public AuthCountoller(ITokenBuilder tokenBuilder, IUserRepository repository)
        {
			_tokenBuilder = tokenBuilder;
			_repository = repository;
		}

        [HttpPost]
		public async Task<IActionResult> Login(UserLoginDTO userDTO)
		{
			User? user = await _repository.GetUser(userDTO.UserName);
			if(user == null || userDTO.Password != user.Password) 
			{
				return BadRequest();
			}

			string token = _tokenBuilder.BuildToken(userDTO);
			return Ok(token);
		}
	}
}
