using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Configurations
{
    public class HotelRoomConfigurations : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.Property(r => r.RoomNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(r => r.RoomNumber)
                .IsUnique();

            builder.HasOne(r => r.RoomDetail)
                .WithOne(h => h.HotelRoom)
                .HasForeignKey<RoomDetail>(h => h.RoomId);

            builder.HasMany(r => r.Reservations)
                .WithOne(x => x.HotelRoom)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

            _ = builder.HasData(
                new HotelRoom { Id = 1, RoomNumber = 101, Capacity = 2, PricePerNight = 100},
                new HotelRoom { Id = 2, RoomNumber = 102, Capacity = 4, PricePerNight = 200}
            );
        }
    }
}
