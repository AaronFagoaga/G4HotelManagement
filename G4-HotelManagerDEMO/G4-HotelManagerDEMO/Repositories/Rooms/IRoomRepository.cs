using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.Rooms
{
    public interface IRoomRepository
    {
        void Add(RoomModel room);
        void Delete(int id);
        void Edit(RoomModel room);
        IEnumerable<RoomModel> GetAll();
        IEnumerable<RoomTypeModel> GetAllRoomTypes();
        IEnumerable<HotelModel> GetAllHotel();
        RoomModel? GetById(int id);
    }
}
