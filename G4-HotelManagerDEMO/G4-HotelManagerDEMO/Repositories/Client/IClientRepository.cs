using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.Cliente
{
    public interface IClientRepository
    {
        void Add (ClientModel client);
        void Delete(int  id);
        void Edit(ClientModel client);
        IEnumerable<ClientModel> GetAll();
        ClientModel? GetById(int id);
    }
}
