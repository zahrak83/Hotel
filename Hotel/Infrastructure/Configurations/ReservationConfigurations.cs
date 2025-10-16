using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.Status)
                      .HasConversion<string>(); 

            builder.Property(r => r.CreatedAt)
                  .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(r => new { r.RoomId, r.CheckInDate, r.CheckOutDate });
                      
        }
    }
}
