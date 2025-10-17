using Hotel.Entities;

namespace Hotel.Interface.IRepositories
{
    public interface IRoomDetailRepository
    {
        List<RoomDetail> GetAll();
        RoomDetail? GetByRoomId(int roomId);
        RoomDetail Add(RoomDetail roomDetail);
        void UpdateHasWifi(int roomId, bool hasWifi);
        void UpdateHasAirConditioner(int roomId, bool hasAirConditioner);
    }
}

