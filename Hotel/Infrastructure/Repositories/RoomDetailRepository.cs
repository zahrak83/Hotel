using Hotel.Entities;
using Hotel.Interface.IRepositories;

namespace Hotel.Infrastructure.Repositories
{
    public class RoomDetailRepository : IRoomDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        public RoomDetailRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public List<RoomDetail> GetAll()
        {
            return _appDbContext.RoomDetails.ToList();
        }

        public RoomDetail? GetByRoomId(int roomId)
        {
            return _appDbContext.RoomDetails
                .FirstOrDefault(r => r.RoomId == roomId);
        }

        public RoomDetail Add(RoomDetail detail)
        {
            _appDbContext.RoomDetails.Add(detail);
            _appDbContext.SaveChanges();
            return detail;
        }

        public void UpdateHasWifi(int roomId, bool hasWifi)
        {
            var existing = GetByRoomId(roomId);
            if (existing != null)
            {
                existing.HasWifi = hasWifi;
                _appDbContext.SaveChanges();
            }
        }

        public void UpdateHasAirConditioner(int roomId, bool hasAirConditioner)
        {
            var existing = GetByRoomId(roomId);
            if (existing != null)
            {
                existing.HasAirConditioner = hasAirConditioner;
                _appDbContext.SaveChanges();
            }
        }
    }
}
