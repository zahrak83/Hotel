using Hotel.Entities;

namespace Hotel.Interface.IRepositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        List<Reservation> GetByUserId(int userId);
        Reservation Add(Reservation reservation);
        bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut);
        Reservation? GetById(int reservationId);
        void CancelReservation(Reservation reservation);
    }
}
