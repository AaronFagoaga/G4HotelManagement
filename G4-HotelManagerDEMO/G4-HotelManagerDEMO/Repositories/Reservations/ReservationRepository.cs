using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ReservationRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IEnumerable<RoomModel> GetAllRooms()
        {
            string query = "SELECT IdRoom, roomName, roomPrice, roomStatus FROM tbl_Room";
            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<RoomModel>(query);
            }
        }

        public IEnumerable<ClientModel> GetAllClient()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spRClient_GetAll";

                return
                    connection.Query<ClientModel>(
                storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spREmployees_GetAll";

                return
                    connection.Query<EmployeeModel>(
                storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<ReservationModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spReservation_GetAll";

                var reservations = connection.Query<ReservationModel, RoomModel, ClientModel, EmployeeModel, ReservationModel>
                    (storedProcedure, (reservation, room, client, employee) => {
                        reservation.Room = room;
                        reservation.Client = client;
                        reservation.Employee = employee;

                        return reservation;
                    },
                    splitOn: "roomName, clientName, emploName",
                    commandType: CommandType.StoredProcedure);

                return reservations;
            }
        }


        public ReservationModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spReservation_GetById";

                return
                    connection.QueryFirstOrDefault<ReservationModel>(
                        storeProcedure,
                        new { IdReservation = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(ReservationModel reservation)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spReservation_Insert";

                connection.Execute(
                    storeProcedure,
                    new { reservation.IdRoom, reservation.IdClient, reservation.arrivalDate, reservation.exitDate, reservation.reservationPrice, reservation.IdEmployee },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(ReservationModel reservation)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spReservation_Update";

                connection.Execute(
                    storeProcedure,
                    new { reservation.IdReservation, reservation.IdRoom, reservation.IdClient, reservation.arrivalDate, reservation.exitDate, reservation.reservationPrice, reservation.IdEmployee },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spReservation_Delete";

                connection.Execute(
                    storeProcedure,
                    new { IdReservation = id },
                    commandType: CommandType.StoredProcedure
                );
            }

        }
    }
}
