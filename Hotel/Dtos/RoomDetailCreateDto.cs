namespace Hotel.Dtos
{
    public class RoomDetailCreateDto
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirConditioner { get; set; }
    }
}
