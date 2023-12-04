using LibraryAuthApi.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAuthApi.DAL.Services
{
	public class TokenBuilder : ITokenBuilder
	{
		private readonly string _secret = "Hello welcome to this conroller and some more bits";

		public string BuildToken(UserLoginDTO user)
		{
			var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
			var descriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(5),
				Issuer = "LibraryAuthAPI",
				Audience = "LibraryAPI",
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)), SecurityAlgorithms.HmacSha256)
			};

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			var jwt = handler.CreateToken(descriptor);
			string token = handler.WriteToken(jwt);
			return token;
		}
	}
}
