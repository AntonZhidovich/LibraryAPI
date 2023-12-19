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
        private readonly ILogger<GetBookByIsbnQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIsbnQueryHandler(
            ILogger<GetBookByIsbnQueryHandler> logger,
            IBookRepository bookRepository, 
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetBookDTO> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookAsync(request.ISBN);
            if (book == null)
            {
                _logger.LogError("Book with ISBN {ISBN} was not found.", request.ISBN);
                throw new ArgumentException("Book with such ISBN not found.");
            }

            return _mapper.Map<Book, GetBookDTO>(book);
        }
    }
}
