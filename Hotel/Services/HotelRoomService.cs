using Hotel.Dtos;
using Hotel.Entities;
using Hotel.Infrastructure.Repositories;
using Hotel.Interface.IRepositories;

namespace Hotel.Services
{
    public class HotelRoomService
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;
        private readonly IRoomDetailRepository _roomDetailRepository;

        public HotelRoomService()
        {
            _hotelRoomRepository = new HotelRoomRepository();
            _roomDetailRepository = new RoomDetailRepository();
        }

        public List<GetHotelRoom> GetAllRooms()
        {
            return _hotelRoomRepository.GetAll();
        }

        public GetHotelRoom AddRoom(HotelRoomCreateDto dto, RoomDetailCreateDto detailDto)
        {
            if (_hotelRoomRepository.IsRoomNumberTaken(dto.RoomNumber))
                throw new InvalidOperationException("Room number already exists.");

            var room = new HotelRoom
            {
                RoomNumber = dto.RoomNumber,
                Capacity = dto.Capacity,
                PricePerNight = dto.PricePerNight,
                CreatedAt = DateTime.Now
            };

            var createdRoom = _hotelRoomRepository.Add(room);

            var detail = new RoomDetail
            {
                RoomId = createdRoom.Id,
                Description = detailDto.Description,
                HasWifi = detailDto.HasWifi,
                HasAirConditioner = detailDto.HasAirConditioner
            };

            _roomDetailRepository.Add(detail);

            return new GetHotelRoom
            {
                Id = createdRoom.Id,
                RoomNumber = createdRoom.RoomNumber,
                Capacity = createdRoom.Capacity,
                PricePerNight = createdRoom.PricePerNight,
                CreatedAt = createdRoom.CreatedAt
            };
        }

        public GetHotelRoom? GetRoomByNumber(int roomNumber)
        {
            var room = _hotelRoomRepository.GetByRoomNumber(roomNumber);

            if (room == null)
                return null;

            return new GetHotelRoom
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                PricePerNight = room.PricePerNight,
                CreatedAt = room.CreatedAt
            };
        }

        public bool IsRoomNumberTaken(int roomNumber)
        {
            return _hotelRoomRepository.IsRoomNumberTaken(roomNumber);
        }
        public void UpdatePrice(int roomId, int price)
        {
            _hotelRoomRepository.UpdatePrice(roomId, price);
        }

    }
}
