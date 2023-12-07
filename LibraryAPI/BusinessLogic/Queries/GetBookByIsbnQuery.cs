using LibraryAPI.BLL.Models;
using MediatR;

namespace LibraryAPI.BLL.Queries
{
	public class GetBookByIsbnQuery : IRequest<GetBookDTO>
	{
		public string ISBN { get; set; }

        public GetBookByIsbnQuery(string isbn)
        {
            ISBN = isbn;
        }
    }
}
