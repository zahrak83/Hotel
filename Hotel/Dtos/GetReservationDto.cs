namespace Hotel.Dtos
{
    public class GetReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
