using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Queries
{
	public class GetBookByIdQuery : IRequest<GetBookDTO>
	{
		public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
