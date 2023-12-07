using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Queries
{
	public class GetBooksQuery : IRequest<IEnumerable<GetBookDTO>>
	{
		public GetBooksQuery() { }
	}
}
