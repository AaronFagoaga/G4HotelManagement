using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoomRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<RoomTypeModel> GetAllRoomTypes()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spRRoomType_GetAll";

                return
                    connection.Query<RoomTypeModel>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<HotelModel> GetAllHotel()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spRHotel_GetAll";

                return
                    connection.Query<HotelModel>(
                storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<RoomModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spRoom_GetAll";

                var rooms = connection.Query<RoomModel, RoomTypeModel, HotelModel, RoomModel>
                    (storedProcedure, (room, roomType, hotel) => {
                        room.RoomType = roomType;
                        room.Hotel = hotel;

                        return room;
                    },
                    splitOn: "typeName,hotelName",
                    commandType: CommandType.StoredProcedure);

                return rooms;
            }
        }

        public RoomModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoom_GetById";

                return
                    connection.QueryFirstOrDefault<RoomModel>(
                        storeProcedure,
                        new { IdRoom = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(RoomModel room)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoom_Insert";

                connection.Execute(
                    storeProcedure,
                    new { room.roomName, room.roomInfo, room.IdType, room.roomPrice, room.roomStatus, room.IdHotel },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(RoomModel room)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoom_Update";

                connection.Execute(
                    storeProcedure,
                    new { room.IdRoom, room.roomName, room.roomInfo, room.IdType, room.roomPrice, room.roomStatus, room.IdHotel },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spRoom_Delete";

                connection.Execute(
                    storeProcedure,
                    new { IdRoom = id },
                    commandType: CommandType.StoredProcedure
                );
            }

        }
    }
}
