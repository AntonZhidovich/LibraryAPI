using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<GetBookDTO>>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;

		public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

        public async Task<IEnumerable<GetBookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
		{
			var books = await _bookRepository.GetBooks();
			return _mapper.Map<IEnumerable<Book>, IEnumerable<GetBookDTO>>(books);
		}
	}
}
