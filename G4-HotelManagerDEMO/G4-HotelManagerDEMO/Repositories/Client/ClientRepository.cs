using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.Cliente
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ClientRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IEnumerable<ClientModel> GetAll()
        {
            using (var connection =  _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spClient_GetAll";

                return connection.Query<ClientModel>(
                                  storeProcedure,
                                  commandType: CommandType.StoredProcedure
                                    );
            }
        }

        public ClientModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spClient_GetById";

                return connection.QueryFirstOrDefault<ClientModel>(
                                  storeProcedure,
                                  new {IdClient = id},
                                  commandType: CommandType.StoredProcedure
                                    );
            }
        }

        public void Add(ClientModel client)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spClient_Insert";

                connection.Execute
                    (
                        storeProcedure,
                        new { client.clientName, client.clientLastName, client.clientAge, client.clientEmail, client.clientPhone  },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spClient_Delete";

                connection.Execute
                    (
                        storeProcedure,
                        new { IdClient = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(ClientModel client)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spClient_Update";

                connection.Execute
                    (
                        storeProcedure,
                        client,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

       

        
    }
}
