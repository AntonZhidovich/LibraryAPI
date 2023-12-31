﻿using AutoMapper;
using LibraryAPI.BLL.Commands;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Repository;
using MediatR;

namespace LibraryAPI.BLL.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly ILogger<DeleteBookCommand> _logger;
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(
            ILogger<DeleteBookCommand> logger,
            IBookRepository bookRepository, 
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetBookAsync(request.Id);
            if (book == null)
            {
                _logger.LogError("Unable to delete a book with ID {id}.", request.Id);
                throw new ArgumentNullException(nameof(request), "The book with such ID was not found");
            }

            await _bookRepository.DeleteBookAsync(book);
        }
    }
}
