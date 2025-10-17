using Hotel.Dtos;
using Hotel.Entities;

namespace Hotel.Interface.IRepositories
{
    public interface IHotelRoomRepository
    {
        List<GetHotelRoom> GetAll();
        HotelRoom? GetByRoomNumber(int roomNumber);
        HotelRoom Add(HotelRoom room);
        bool IsRoomNumberTaken(int roomNumber);
        HotelRoom? GetByRoomId(int Id);
        void UpdatePrice(int id, int pricePerNight);
    }
}

