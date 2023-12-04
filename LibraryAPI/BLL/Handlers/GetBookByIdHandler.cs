using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookDTO>
	{

		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<GetBookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
		{
			Book? book = await _bookRepository.GetBook(request.Id);
			if (book != null)
			{
				return _mapper.Map<Book, GetBookDTO>(book);
			}

			throw new ArgumentException("Book with such ID not found.");
		}
	}
}
