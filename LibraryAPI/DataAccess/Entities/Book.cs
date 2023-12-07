namespace LibraryAPI.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime DateOfTaking { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
