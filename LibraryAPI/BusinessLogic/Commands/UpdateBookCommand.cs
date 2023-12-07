using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Commands
{
	public class UpdateBookCommand : IRequest
	{
		public int Id { get; set; }
		public UpdateBookDTO BookDTO { get; }

        public UpdateBookCommand(int id, UpdateBookDTO bookDTO)
        {
			BookDTO = bookDTO;
			Id = id;
		}
	}
}
