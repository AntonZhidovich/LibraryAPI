using LibraryAPI.BLL.Models;
using LibraryAPI.BusinessLogic.Models;
using MediatR;

namespace LibraryAPI.BLL.Queries
{
    public class GetBooksQuery : IRequest<BooksPageList<GetBookDTO>>
    {
        public BooksPageParameters BooksPageParameters { get; set; }

        public GetBooksQuery(BooksPageParameters booksPageParameters) 
        {
            BooksPageParameters = booksPageParameters;
        }
    }
}
