using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Presentation.ExceptionHandlers
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

        /// <summary>
        /// Sign in with a password
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            var command = new UserLoginQuery(userDTO);
            string token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
