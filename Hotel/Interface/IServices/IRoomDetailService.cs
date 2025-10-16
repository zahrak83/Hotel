using Hotel.Dtos;

namespace Hotel.Interface.IServices
{
    public interface IRoomDetailService
    {
        GetRoomDetailDto? GetByRoomId(int roomId);
        List<GetRoomDetailDto> GetAll();
        void UpdateDescription(int roomId, string description);
        void UpdateHasWifi(int roomId, bool hasWifi);
        void UpdateHasAirConditioner(int roomId, bool hasAirConditioner);
    }
}
