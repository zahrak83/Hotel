using Hotel.Dtos;
using Hotel.Entities;
using Hotel.Enum;
using Hotel.Infrastructure.Repositories;
using Hotel.Interface.IRepositories;
using Hotel.Interface.IServices;

namespace Hotel.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();
        }

        public List<GetReservationDto> GetAllReservations()
        {
            return _reservationRepository.GetAll()
                .Select(r => new GetReservationDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    RoomId = r.RoomId,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    Status = r.Status.ToString(),
                    CreatedAt = r.CreatedAt
                }).ToList();
        }

        public List<GetReservationDto> GetReservationsByUser(int userId)
        {
            return _reservationRepository.GetByUserId(userId)
                .Select(r => new GetReservationDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    RoomId = r.RoomId,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    Status = r.Status.ToString(),
                    CreatedAt = r.CreatedAt
                }).ToList();
        }

        public GetReservationDto CreateReservation(ReservationCreateDto dto)
        {
            if (!_reservationRepository.IsRoomAvailable(dto.RoomId, dto.CheckInDate, dto.CheckOutDate))
                throw new InvalidOperationException("Room is already booked for these dates.");

            var reservation = new Reservation
            {
                UserId = dto.UserId,
                RoomId = dto.RoomId,
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                Status = Enum.StatusEnum.Pending,
                CreatedAt = DateTime.Now
            };

            var created = _reservationRepository.Add(reservation);

            return new GetReservationDto
            {
                Id = created.Id,
                UserId = created.UserId,
                RoomId = created.RoomId,
                CheckInDate = created.CheckInDate,
                CheckOutDate = created.CheckOutDate,
                Status = created.Status.ToString(),
                CreatedAt = created.CreatedAt
            };
        }

        public void CancelReservation(int reservationId)
        {
            var reservation = _reservationRepository.GetById(reservationId);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            if (reservation.Status == StatusEnum.Canceled)
                throw new InvalidOperationException("Reservation is already canceled.");

            _reservationRepository.CancelReservation(reservation);
        }
    }
}
