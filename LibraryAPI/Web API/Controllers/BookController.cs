using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Web_API.Controllers
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

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<GetBookDTO>))]
        public async Task<IActionResult> GetBooks()
		{
			GetBooksQuery getBooksQuery = new GetBooksQuery();
			var books = await _mediator.Send(getBooksQuery);
			return Ok(books);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(GetBookDTO))]
		public async Task<IActionResult> GetBook(int id)
		{
			GetBookByIdQuery query = new GetBookByIdQuery(id);
			var book = await _mediator.Send(query);
			return Ok(book);
		}

		[HttpGet("/isbn/{isbn}")]
		[ProducesResponseType(200, Type = typeof(GetBookDTO))]
		public async Task<IActionResult> GetBook(string isbn)
		{
			GetBookByIsbnQuery query = new GetBookByIsbnQuery(isbn);
			var book = await _mediator.Send(query);
			return Ok(book);
		}

		[HttpPost]
		[ProducesResponseType(200, Type = typeof(int))]
		public async Task<IActionResult> CreateBook(CreateBookDTO book)
		{
			CreateBookCommand command = new CreateBookCommand(book);
			return Ok(await _mediator.Send(command));
		}

		[HttpPut("{id}")]
		[ProducesResponseType(200, Type = typeof(bool))]
		public async Task<IActionResult> UpdateBook(int id, UpdateBookDTO updateBook)
		{
			UpdateBookCommand command = new UpdateBookCommand(id, updateBook);
			return Ok(await _mediator.Send(command));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(bool))]
		public async Task<IActionResult> DeleteBook(int id)
		{
			DeleteBookCommand command = new DeleteBookCommand(id);
			return Ok(await _mediator.Send(command));
		}
	}
}
