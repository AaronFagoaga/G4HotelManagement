    using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.RoomTypes
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoomTypeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<RoomTypeModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoomType_GetAll";

                return connection.Query<RoomTypeModel>(
                                        storeProcedure,
                                        commandType: CommandType.StoredProcedure
                                        );
            }
        }

        public RoomTypeModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoomType_GetById";

                return connection.QueryFirstOrDefault<RoomTypeModel>(
                                    storeProcedure,
                                    new { IdType = id },
                                    commandType: CommandType.StoredProcedure
                                   );
            }
        }

        public void Add(RoomTypeModel roomType)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoomType_Insert";

                connection.Execute(
                    storeProcedure,
                    new { roomType.typeName, roomType.typeInfo, roomType.typeCapacity },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoomType_Delete";

                connection.Execute(
                    storeProcedure,
                    new { IdType = id },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(RoomTypeModel roomType)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoomType_Update";

                connection.Execute(
                        storeProcedure,
                        roomType,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
