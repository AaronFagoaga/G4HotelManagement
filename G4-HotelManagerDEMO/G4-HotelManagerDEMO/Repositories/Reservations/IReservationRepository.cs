using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.Reservations
{
    public interface IReservationRepository
    {
        void Add(ReservationModel reservation);
        void Delete(int id);
        void Edit(ReservationModel reservation);
        IEnumerable<ReservationModel> GetAll();
        IEnumerable<ClientModel> GetAllClient();
        IEnumerable<EmployeeModel> GetAllEmployees();
        IEnumerable<RoomModel> GetAllRooms();
        ReservationModel? GetById(int id);
    }
}
