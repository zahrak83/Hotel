using Hotel.Entities;

namespace Hotel.Interface.IRepositories
{
    public interface IRoomDetailRepository
    {
        List<RoomDetail> GetAll();
        RoomDetail? GetByRoomId(int roomId);
        RoomDetail Add(RoomDetail roomDetail);
        void UpdateDescription(int roomId, string description);
        void UpdateHasWifi(int roomId, bool hasWifi);
        void UpdateHasAirConditioner(int roomId, bool hasAirConditioner);
    }
}

