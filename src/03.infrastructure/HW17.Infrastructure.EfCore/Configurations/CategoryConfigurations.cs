using HW17.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Infrastructure.EfCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.Description).HasMaxLength(255);
            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasData(new List<Category>(){
                new Category { Id = 1, Name = "رمان و داستان" , Description = "معاصر، کلاسیک" , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0),ImagePath ="/images/Category/stack-of-books.png" },
                new Category { Id = 2, Name = "فلسفه و منطق" , Description = "غرب و شرق" , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0),ImagePath = "/images/Category/artificial-intelligence.png" },
                new Category { Id = 3, Name = "علمی و تاریخی" , Description = "فناوری و تاریخ" , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0),ImagePath = "/images/Category/microscope.png" },
                new Category { Id = 4, Name = "کودک و نوجوان" , Description = "داستان های مصور" , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0),ImagePath = "/images/Category/student.png" },
                new Category { Id = 5, Name = "هنر و معماری" , Description = "طراحی و نقاشی" , CreatedAt = new DateTime(2025, 10, 11, 14, 30, 0), ImagePath = "/images/Category/color-pallete.png" },

            });
        }
    }
}
