using LibraryAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.DAL.Repository
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

	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(b => b.Id);

			builder.Property(b => b.Title)
				.IsRequired()
				.IsUnicode(true)
				.HasMaxLength(100);

			builder.HasIndex(b => b.ISBN)
				.IsUnique();

			builder.Property(b => b.Description)
				.IsRequired(false)
				.IsUnicode(true)
				.HasDefaultValue("")
				.HasMaxLength(350);

			builder.Property(b => b.Author)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(b => b.Genre)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(b => b.DateOfTaking)
				.IsRequired()
				.HasColumnType("date")
				.HasColumnName("DateOfTaking");

			builder.Property(b => b.DateOfReturn)
				.IsRequired()
				.HasColumnType("date")
				.HasColumnName("DateOfReturn");

			Initialize(builder);
		}

		private void Initialize(EntityTypeBuilder<Book> builder)
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
