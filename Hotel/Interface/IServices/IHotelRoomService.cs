using Hotel.Dtos;
using Hotel.Entities;

namespace Hotel.Interface.IServices
{
    public interface IHotelRoomService
    {
        List<GetHotelRoom> GetAllRooms();
        GetHotelRoom AddRoom(HotelRoomCreateDto dto, RoomDetailCreateDto detailDto);
        GetHotelRoom? GetRoomByNumber(int roomNumber);
        public void UpdatePrice(int roomId, int price);
    }
}
