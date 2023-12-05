using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Web_API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : Controller
	{
		private readonly IMediator _mediator;

		public AccountController(IMediator mediator)
        {
			_mediator = mediator;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDTO userDTO)
		{
			UserLoginCommand command = new UserLoginCommand(userDTO);
			string token = await _mediator.Send(command);
			return Ok(token);
		}
	}
}
