using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.BLL.Queries;
using LibraryAPI.BusinessLogic.Models;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BooksPageList<GetBookDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BooksPageList<GetBookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync(request.BooksPageParameters.CurrentPage,
                request.BooksPageParameters.PageSize);

            var count = _bookRepository.Count();
            int pagesCount = (int)Math.Ceiling((double)count / request.BooksPageParameters.PageSize);
            BooksPageList<GetBookDTO> booksPage = new BooksPageList<GetBookDTO>
            {
                PagesCount = pagesCount,
                CurrentPage = request.BooksPageParameters.CurrentPage,
                PageSize = request.BooksPageParameters.PageSize,
                Items = _mapper.Map<IEnumerable<Book>, IEnumerable<GetBookDTO>>(books)
            };
            return booksPage;
        }
    }
}
