using Hotel.Enum;

namespace Hotel.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public StatusEnum Status { get; set; }
    }
}
