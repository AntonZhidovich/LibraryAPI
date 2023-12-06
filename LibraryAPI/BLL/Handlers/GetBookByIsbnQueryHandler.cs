using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class GetBookByIsbnQueryHandler : IRequestHandler<GetBookByIsbnQuery, GetBookDTO>
	{
		private readonly ILogger<GetBookByIsbnQuery> _logger;
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public GetBookByIsbnQueryHandler(
			ILogger<GetBookByIsbnQuery> logger,
			IBookRepository bookRepository, 
			IMapper mapper)
		{
			_logger = logger;
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<GetBookDTO> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
		{
			Book? book = await _bookRepository.GetBook(request.ISBN);
			if (book != null)
			{
				return _mapper.Map<Book, GetBookDTO>(book);
			}
			_logger.LogError("Book with ISBN {ISBN} was not found", request.ISBN);
			throw new ArgumentException("Book with such ISBN not found.");
		}
	}
}
