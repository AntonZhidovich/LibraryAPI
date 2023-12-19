using LibraryAPI.DAL.Entities;
using LibraryAPI.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Data
{
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public BookDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
