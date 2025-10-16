namespace Hotel.Dtos
{
    public class GetHotelRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int PricePerNight { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
