using LibraryAPI.BLL.Queries;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
	{
		private readonly ILogger<UserLoginQueryHandler> _logger;
		private readonly IConfiguration _configuration;

		public UserLoginQueryHandler(ILogger<UserLoginQueryHandler> logger, IConfiguration configuration)
        {
			_logger = logger;
			_configuration = configuration;
		}

        public async Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
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
