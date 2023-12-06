using AutoMapper;
using FluentValidation;
using LibraryAPI.BLL.Commands;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Models;
using LibraryAPI.DAL.Repository;
using MediatR;
using Microsoft.Identity.Client;

namespace LibraryAPI.BLL.Handlers
{
	public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
	{
		private readonly IBookRepository _bookRepository;
		private readonly IMapper _mapper;
		private readonly IValidator<UpdateBookDTO> _validator;

		public UpdateBookCommandHandler(
			IBookRepository bookRepository,
			IMapper mapper,
			IValidator<UpdateBookDTO> validator)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request.BookDTO, cancellationToken);
			if (!validationResult.IsValid)
			{
				throw new BadHttpRequestException("Invalid data.");
			}

			Book book = _mapper.Map<UpdateBookDTO, Book>(request.BookDTO);
			book.Id = request.Id;
			await _bookRepository.UpdateBook(book);
			return true;
		}
	}
}
