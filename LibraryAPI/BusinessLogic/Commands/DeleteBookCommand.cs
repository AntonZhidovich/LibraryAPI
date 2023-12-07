using MediatR;

namespace LibraryAPI.BLL.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
