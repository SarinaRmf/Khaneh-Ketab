using HW17.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW17.Infrastructure.EfCore.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.PasswordHash).IsRequired()
                .HasMaxLength(150);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.OwnsOne(u => u.Phone, mobile =>
            {
                mobile.Property(m => m.Value)
                .HasColumnName("Mobile")
                .HasMaxLength(11)
                .IsRequired(true);
            });


        }
    }
}
