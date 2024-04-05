using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.Hotels
{
    public interface IHotelRepository
    {
        void Add(HotelModel hotel);
        void Delete(int id);
        void Edit(HotelModel hotel);
        IEnumerable<HotelModel> GetAll();
        HotelModel? GetById(int id);
    }
}
