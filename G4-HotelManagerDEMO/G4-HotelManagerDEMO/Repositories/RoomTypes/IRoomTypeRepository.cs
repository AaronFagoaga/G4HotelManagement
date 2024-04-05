using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.RoomTypes
{
    public interface IRoomTypeRepository
    {
        void Add(RoomTypeModel roomType);
        void Delete(int id);
        void Edit(RoomTypeModel roomType);
        IEnumerable<RoomTypeModel> GetAll();
        RoomTypeModel? GetById(int id);
    }
}
