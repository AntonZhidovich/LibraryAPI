using LibraryAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DataAccess.Data
{
    public static class BookDBInitializerExtension
    {
        public static void Seed(this EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
               new Book
               {
                   Id = 1,
                   ISBN = "978-5-06-002611-5",
                   Title = "Портрет Дориана Грея",
                   Author = "Оскар Уайльд",
                   Description = "Описание первой книги",
                   Genre = "Готический роман",
                   DateOfTaking = DateTime.Now,
                   DateOfReturn = DateTime.Now.AddMonths(1)
               },
               new Book
               {
                   Id = 2,
                   ISBN = "978-5-699-12014-7",
                   Title = "Безмолвный Пациент",
                   Author = "Алекс Михаэлидес",
                   Genre = "Триллер",
                   DateOfTaking = DateTime.Now,
                   DateOfReturn = DateTime.Now.AddMonths(2)
               });
        }
    }
}
