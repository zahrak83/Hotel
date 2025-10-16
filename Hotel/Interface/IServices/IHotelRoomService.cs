using Hotel.Dtos;
using Hotel.Entities;

namespace Hotel.Interface.IServices
{
    public interface IHotelRoomService
    {
        List<GetHotelRoom> GetAllRooms();
        GetHotelRoom AddRoom(HotelRoomCreateDto room);
        GetHotelRoom? GetRoomByNumber(int roomNumber);
        bool IsRoomNumberTaken(int roomNumber);
        public void UpdatePrice(int roomId, int price);
    }
}
