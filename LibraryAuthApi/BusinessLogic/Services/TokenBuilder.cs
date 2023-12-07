using LibraryAuthApi.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAuthApi.DAL.Services
{
	public class TokenBuilder : ITokenBuilder
	{
		private readonly IConfiguration _configuration;

		public TokenBuilder(IConfiguration configuration)
        {
			_configuration = configuration;
		}

        public string BuildToken(User user)
		{
			var claims = new List<Claim> {
				new Claim(ClaimTypes.NameIdentifier, user.UserName),
				new Claim(ClaimTypes.Name, user.Name),
			};
			var symmetricKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtParameters:Key") ?? ""));
			var descriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(5),
				Issuer = _configuration.GetValue<string>("JwtParameters:Issuer"),
				Audience = _configuration.GetValue<string>("JwtParameters:Audience"),
				SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256)
			};

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			var jwt = handler.CreateToken(descriptor);
			string token = handler.WriteToken(jwt);
			return token;
		}
	}
}
