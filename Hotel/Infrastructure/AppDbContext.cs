using Hotel.Entities;
using Hotel.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Hotel.Infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DG1LLR4\SQLEXPRESS;Database=Hotel;Integrated Security=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomDetail> RoomDetails { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new HotelRoomConfigurations());
            modelBuilder.ApplyConfiguration(new ReservationConfigurations());
            modelBuilder.ApplyConfiguration(new RoomDetailConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
