namespace Hotel.Entities
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int PricePerNight { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Reservation> Reservations { get; set; }
        public RoomDetail RoomDetail { get; set; }
    }
}
