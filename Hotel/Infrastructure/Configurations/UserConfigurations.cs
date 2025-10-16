using Hotel.Entities;
using Hotel.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Hotel.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Role)
                .HasConversion<string>();

            builder.Property(u => u.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

            builder.HasMany(u => u.reservations)
                      .WithOne(r => r.User)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new User { Id = 1, Username = "admin", Password = "1234", Role = RoleEnum.Admin},
                new User { Id = 2, Username = "reception", Password = "1234", Role = RoleEnum.Receptionist},
                new User { Id = 3, Username = "user1", Password = "1234", Role = RoleEnum.NormalUser }
                );
        }
    }
}
