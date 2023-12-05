using LibraryAPI.BLL.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Text.Json;

namespace LibraryAPI.BLL.Handlers
{
	public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
	{
		private readonly IConfiguration _configuration;

		public UserLoginCommandHandler(IConfiguration configuration)
        {
			_configuration = configuration;
		}

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
		{
			HttpClient client = new HttpClient();
			string? authorizatinUri = _configuration.GetValue<string>("AuthorizationURI");
			using var response = await client.PostAsJsonAsync(authorizatinUri, request.UserDTO);
			if (!response.IsSuccessStatusCode)
			{ 
				throw new ArgumentException("Invalid username or password");
			}
			string token = await response.Content.ReadAsStringAsync();
			return token;
		}
	}
}
