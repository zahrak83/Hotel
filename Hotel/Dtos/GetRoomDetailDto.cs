namespace Hotel.Dtos
{
    public class GetRoomDetailDto
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirConditioner { get; set; }
    }
}
