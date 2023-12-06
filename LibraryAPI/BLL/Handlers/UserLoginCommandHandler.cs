using LibraryAPI.BLL.Commands;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
	{
		private readonly ILogger<UserLoginCommandHandler> _logger;
		private readonly IConfiguration _configuration;

		public UserLoginCommandHandler(ILogger<UserLoginCommandHandler> logger, IConfiguration configuration)
        {
			_logger = logger;
			_configuration = configuration;
		}

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
		{
			HttpClient client = new HttpClient();
			string? authorizatinUri = _configuration.GetValue<string>("AuthorizationURI");
			using var response = await client.PostAsJsonAsync(authorizatinUri, request.UserDTO);
			if (!response.IsSuccessStatusCode)
			{ 
				_logger.LogError("Invalid username: \"{username}\" or password: \"{password}\".", 
					request.UserDTO.UserName, request.UserDTO.Password);
				throw new ArgumentException("Invalid username or password.");
			}
			string token = await response.Content.ReadAsStringAsync();
			return token;
		}
	}
}
