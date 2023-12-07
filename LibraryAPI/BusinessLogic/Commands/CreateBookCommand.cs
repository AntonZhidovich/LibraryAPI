using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Commands
{
	public class CreateBookCommand : IRequest
	{
		public CreateBookDTO BookDTO { get; set; }

        public CreateBookCommand(CreateBookDTO bookDTO)
        {
            BookDTO = bookDTO;
        }
    }
}
