using Hotel.Dtos;
using Hotel.Entities;
using Hotel.Interface.IRepositories;

namespace Hotel.Infrastructure.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly AppDbContext _appDbContext;

        public HotelRoomRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public HotelRoom Add(HotelRoom room)
        {
            _appDbContext.HotelRooms.Add(room);
            _appDbContext.SaveChanges();
            return room;
        }

        public List<GetHotelRoom> GetAll()
        {
            return _appDbContext.HotelRooms
                 .Select(r => new GetHotelRoom
                 {
                     Id = r.Id,
                     RoomNumber = r.RoomNumber,
                     Capacity = r.Capacity,
                     PricePerNight = r.PricePerNight,
                     CreatedAt = r.CreatedAt,
                 }).ToList();
        }

        public HotelRoom? GetByRoomNumber(int roomNumber)
        {
            return _appDbContext.HotelRooms
                .FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public bool IsRoomNumberTaken(int roomNumber)
        {
            return _appDbContext.HotelRooms
                .Any(r => r.RoomNumber == roomNumber);
        }

        public HotelRoom? GetByRoomId(int Id)
        {
            return _appDbContext.HotelRooms
                .FirstOrDefault(r => r.Id == Id);
        }

        public void UpdatePrice(int id, int pricePerNight)
        {
            var existing = GetByRoomId(id);
            if (existing != null)
            {
                existing.PricePerNight = pricePerNight;
                _appDbContext.SaveChanges();
            }

        }
    }
}
