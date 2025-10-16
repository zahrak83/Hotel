using Hotel.Dtos;

namespace Hotel.Interface.IServices
{
    public interface IReservationService
    {
        List<GetReservationDto> GetAllReservations();
        List<GetReservationDto> GetReservationsByUser(int userId);
        GetReservationDto CreateReservation(ReservationCreateDto dto);
        void CancelReservation(int reservationId);
    }
}
