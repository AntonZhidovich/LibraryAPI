using LibraryAuthApi.BLL.Services;
using LibraryAuthApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAuthApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthorizationController : Controller
	{
		private readonly ISignInService _signInService;

		public AuthorizationController(ISignInService signInService)
        {
			_signInService = signInService;
		}

        [HttpPost]
		public async Task<IActionResult> SignIn(UserLoginDTO userDTO)
		{
			string token = await _signInService.SignIn(userDTO);
			return Ok(token);
		}
	}
}
