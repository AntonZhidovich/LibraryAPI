using LibraryAuthApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAuthApi.BLL.Data
{
	public class UserDBContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;

		public UserDBContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BookConfiguration());
		}
	}


	public class BookConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(u => u.Password)
				.IsRequired();

			Initialize(builder);
		}

		private void Initialize(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User
				{
					Id = 1,
					Name = "Dmitry Ivanov",
					UserName = "Dmitry.Ivanov",
					Password = "pa$$w0rd"
				});
		}
	}
}