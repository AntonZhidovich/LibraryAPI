using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.DAL.Entities;
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
			var book = await _bookRepository.GetBook(request.ISBN);
			return _mapper.Map<Book, GetBookDTO>(book);
		}
	}
}
