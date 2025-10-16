using Hotel.Dtos;
using Hotel.Infrastructure.Repositories;
using Hotel.Interface.IRepositories;
using Hotel.Interface.IServices;

namespace Hotel.Services
{
    public class RoomDetailService : IRoomDetailService
    {
        private readonly IRoomDetailRepository _roomDetailRepository;

        public RoomDetailService()
        {
            _roomDetailRepository = new RoomDetailRepository();
        }

        public GetRoomDetailDto? GetByRoomId(int roomId)
        {
            var detail = _roomDetailRepository.GetByRoomId(roomId);
            
            if (detail == null) 
                return null;

            return new GetRoomDetailDto
            {
                RoomId = detail.RoomId,
                Description = detail.Description,
                HasWifi = detail.HasWifi,
                HasAirConditioner = detail.HasAirConditioner
            };
        }

        public List<GetRoomDetailDto> GetAll()
        {
            return _roomDetailRepository.GetAll()
                .Select(d => new GetRoomDetailDto
                {
                    RoomId = d.RoomId,
                    Description = d.Description,
                    HasWifi = d.HasWifi,
                    HasAirConditioner = d.HasAirConditioner
                }).ToList();
        }

        public void UpdateDescription(int roomId, string description)
        {
            _roomDetailRepository.UpdateDescription(roomId, description);
        }

        public void UpdateHasWifi(int roomId, bool hasWifi)
        {
            _roomDetailRepository.UpdateHasWifi(roomId, hasWifi);
        }

        public void UpdateHasAirConditioner(int roomId, bool hasAirConditioner)
        {
            _roomDetailRepository.UpdateHasAirConditioner(roomId, hasAirConditioner);
        }
    }
}
