using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DataAccess.Data
{
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

            builder.Seed();
        }
    }
}
