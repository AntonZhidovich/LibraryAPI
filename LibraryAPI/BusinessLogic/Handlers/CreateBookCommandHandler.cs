using AutoMapper;
using FluentValidation;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookDTO> _validator;

        public CreateBookCommandHandler(
            ILogger<CreateBookCommandHandler> logger,
            IBookRepository bookRepository, 
            IMapper mapper,
            IValidator<CreateBookDTO> validator)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.BookDTO, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Unable to create a book. The input for book is invalid. Errors: {Errors}.", validationResult.Errors);
                throw new BadHttpRequestException("Invalid data.");
            }

            Book book = _mapper.Map<CreateBookDTO, Book>(request.BookDTO);
            await _bookRepository.CreateBook(book);
        }
    }
}
