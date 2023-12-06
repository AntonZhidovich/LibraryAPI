using AutoMapper;
using FluentValidation;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
	public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
	{

		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<CreateBookDTO> _validator;

		public CreateBookCommandHandler(
			IBookRepository bookRepository, 
			IMapper mapper,
			IValidator<CreateBookDTO> validator)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.BookDTO, cancellationToken);
			if (!validationResult.IsValid)
			{
				throw new BadHttpRequestException("Invalid data.");
			}

			Book book = _mapper.Map<CreateBookDTO, Book>(request.BookDTO);
			await _bookRepository.CreateBook(book);
			return book.Id;
		}
	}
}
