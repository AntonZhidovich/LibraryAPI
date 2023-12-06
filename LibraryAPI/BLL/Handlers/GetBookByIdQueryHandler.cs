using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookDTO>
	{
		private readonly ILogger<GetBookByIdQueryHandler> _logger;
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public GetBookByIdQueryHandler(
			ILogger<GetBookByIdQueryHandler> logger,
			IBookRepository bookRepository, 
			IMapper mapper)
		{
			_logger = logger;
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
			_logger.LogError("Book with ID {id} was not found", request.Id);
			throw new ArgumentException("Book with such ID not found.");
		}
	}
}
