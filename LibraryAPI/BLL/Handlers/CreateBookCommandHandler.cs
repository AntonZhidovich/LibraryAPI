using AutoMapper;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
	{

		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			Book book = _mapper.Map<CreateBookDTO, Book>(request.BookDTO);
			await _bookRepository.CreateBook(book);
			return book.Id;
		}
	}
}
