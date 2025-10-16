using Hotel.Entities;
using Hotel.Enum;
using Hotel.Interface.IRepositories;

namespace Hotel.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReservationRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public Reservation Add(Reservation reservation)
        {
            _appDbContext.Reservations.Add(reservation);
            _appDbContext.SaveChanges();
            return reservation;
        }

        public List<Reservation> GetAll()
        {
            return _appDbContext.Reservations.ToList();
        }

        public List<Reservation> GetByUserId(int userId)
        {
            return _appDbContext.Reservations
                .Where(r => r.UserId == userId)
                .ToList();
        }

        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            return !_appDbContext.Reservations
                .Any(r => r.RoomId == roomId && r.Status != Enum.StatusEnum.Canceled && (checkIn < r.CheckOutDate && checkOut > r.CheckInDate));
        }

        public Reservation? GetById(int reservationId)
        {
            return _appDbContext.Reservations.FirstOrDefault(r => r.Id == reservationId);
        }

        public void CancelReservation(Reservation reservation)
        {
            reservation.Status = StatusEnum.Canceled;
            _appDbContext.SaveChanges();
        }
    }
}
