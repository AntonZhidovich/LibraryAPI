using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.BusinessLogic.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Presentation.ExceptionHandlers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetBookDTO>))]
        public async Task<IActionResult> GetBooksAsync([FromQuery] BooksPageParameters parameters)
        {
            var getBooksQuery = new GetBooksQuery(parameters);
            var books = await _mediator.Send(getBooksQuery);
            return Ok(books);
        }

        /// <summary>
        /// Get a book with a given ID
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GetBookDTO))]
        public async Task<IActionResult> GetBookAsync([FromRoute] int id)
        {
            var query = new GetBookByIdQuery(id);
            var book = await _mediator.Send(query);
            return Ok(book);
        }

        /// <summary>
        /// Get a book with a given ISBN code
        /// </summary>
        [Authorize]
        [HttpGet("isbn/{isbn}")]
        [ProducesResponseType(200, Type = typeof(GetBookDTO))]
        public async Task<IActionResult> GetBookAsync([FromRoute] string isbn)
        {
            var query = new GetBookByIsbnQuery(isbn);
            var book = await _mediator.Send(query);
            return Ok(book);
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDTO book)
        {
            var command = new CreateBookCommand(book);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Update a book with a given ID
        /// </summary>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] UpdateBookDTO updateBook)
        {
            var command = new UpdateBookCommand(id, updateBook);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete a book with a given	ID
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            var command = new DeleteBookCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
