using AutoMapper;
using LibraryAPI.BLL.Commands;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public DeleteBookHandler(IBookRepository bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
		{
			Book? book = await _bookRepository.GetBook(request.Id);
			if (book == null)
			{
				throw new ArgumentNullException(nameof(request), "The book with this ID was not found");
			}

			await _bookRepository.DeleteBook(book);
			return true;
		}
	}
}
