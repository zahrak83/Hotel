using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Configurations
{
    public class RoomDetailConfigurations : IEntityTypeConfiguration<RoomDetail>
    {
        public void Configure(EntityTypeBuilder<RoomDetail> builder)
        {
            builder.HasKey(d => d.RoomId);

            builder.Property(d => d.Description)
                      .HasMaxLength(200);

            builder.HasData(
                new RoomDetail { RoomId = 1, Description = "Double room with WiFi", HasWifi = true, HasAirConditioner = true },
                new RoomDetail { RoomId = 2, Description = "Family suite", HasWifi = true, HasAirConditioner = false }
            );
        }
    }
}
