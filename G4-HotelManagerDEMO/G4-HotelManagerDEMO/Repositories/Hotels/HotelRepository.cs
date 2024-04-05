using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public HotelRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

		public IEnumerable<HotelModel> GetAll()
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spHotel_GetAll";

				return connection.Query<HotelModel>(
										storeProcedure,
										commandType: CommandType.StoredProcedure
										);
			}
		}

		public HotelModel? GetById(int id)
		{
			using (var connection = _dataAccess.GetConnection())
			{
				string storeProcedure = "dbo.spHotel_GetById";

				return connection.QueryFirstOrDefault<HotelModel>(
									storeProcedure,
									new { IdHotel = id },
									commandType: CommandType.StoredProcedure
								   );
			}
		}

		public void Add(HotelModel hotel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spHotel_Insert";

                connection.Execute(
                    storeProcedure,
                    new { hotel.hotelName, hotel.hotelInfo, hotel.hotelPhone, hotel.hotelEmail, hotel.hotelAddress, hotel.hotelCategory },
                    commandType: CommandType.StoredProcedure
                    );
            }

        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spHotel_Delete";

                connection.Execute(
                    storeProcedure,
                    new { IdHotel = id },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void Edit(HotelModel hotel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spHotel_Update";

                connection.Execute(
                        storeProcedure,
                        hotel,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
