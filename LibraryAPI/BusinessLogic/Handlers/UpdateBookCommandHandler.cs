using AutoMapper;
using FluentValidation;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
	{
		private readonly ILogger<UpdateBookCommandHandler> _logger;
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateBookDTO> _validator;

		public UpdateBookCommandHandler(
			ILogger<UpdateBookCommandHandler> logger,
			IBookRepository bookRepository,
			IMapper mapper,
			IValidator<UpdateBookDTO> validator)
		{
			_logger = logger;
			_bookRepository = bookRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.BookDTO, cancellationToken);
			if (!validationResult.IsValid)
			{
				_logger.LogError("Unable to update a book. The input for book is invalid. Errors: {Errors}", validationResult.Errors);
				throw new BadHttpRequestException("Invalid data.");
			}

			Book book = _mapper.Map<UpdateBookDTO, Book>(request.BookDTO);
			book.Id = request.Id;
			try
			{
				await _bookRepository.UpdateBook(book);
			}
			catch
			{
				_logger.LogError("Unable to update a book with ID {id}.", request.Id);
				throw new ArgumentException("Book with such ID not found.");
			}
		}
	}
}
