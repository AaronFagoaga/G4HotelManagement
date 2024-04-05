using System.Data;

namespace G4_HotelManagerDEMO.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}
