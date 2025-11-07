using HW17.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW17.Infrastructure.EfCore.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(b => b.Title).HasMaxLength(100);
            builder.Property(b => b.Auther).HasMaxLength(100);

            builder.HasData(new List<Book>
            {
                new Book { Id = 1, Title = "هزار و یک شب", Auther = "آنتونیو مارکز" , CategoryId = 1 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 400 , Price = 490000, ImagePath = "/images/books/hezaroyekshab.jpg" },
                new Book { Id = 3, Title = "انسان خداگونه", Auther = "لورا هریس" , CategoryId = 2 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 820 , Price = 620000, ImagePath = "/images/books/ensan.jpg" },
                new Book { Id = 2, Title = "اساطیر جهان", Auther = "دکتر جان اسمیت" , CategoryId = 3 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 310 , Price = 750000, ImagePath = "/images/books/rome.jpg" },
                new Book { Id = 4, Title = "قصه های من و بابام", Auther = "مائوریسیو گاند " , CategoryId = 4 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 550 , Price = 380000 ,ImagePath = "/images/books/ManoBabam-3.jpg"},
                new Book { Id = 5, Title = "هنر در گذر زمان", Auther = "دایان وایلد" , CategoryId = 5 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 940 , Price = 550000 , ImagePath = "/images/books/honar.jpg" },
                new Book { Id = 6, Title = "انسان خردمند", Auther = "دایان وایلد" , CategoryId = 5 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 940 , Price = 550000 , ImagePath = "/images/books/kherad.jpg" },
                new Book { Id = 7, Title = "دایی جان ناپلئون", Auther = "دایان وایلد" , CategoryId = 5 , CreatedAt = new DateTime (2025, 10, 11, 14, 30, 0), PageCount = 940 , Price = 550000 , ImagePath = "/images/books/napelon.jpg" },

            });

        }
    }
}
