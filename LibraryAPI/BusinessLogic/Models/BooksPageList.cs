namespace LibraryAPI.BusinessLogic.Models
{
    public class BooksPageList<T>
    {
        public int PagesCount {  get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; } = null!;
    }
}
