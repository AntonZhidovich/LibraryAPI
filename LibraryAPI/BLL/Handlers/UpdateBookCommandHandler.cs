using AutoMapper;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;
using Microsoft.Identity.Client;

namespace LibraryAPI.BLL.Handlers
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
	{

		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{
			Book book = _mapper.Map<UpdateBookDTO, Book>(request.BookDTO);
			book.Id = request.Id;
			await _bookRepository.UpdateBook(book);
			return true;
		}
	}
}
