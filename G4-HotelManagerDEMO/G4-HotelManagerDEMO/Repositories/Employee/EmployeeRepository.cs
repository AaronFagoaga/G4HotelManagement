using Dapper;
using G4_HotelManagerDEMO.Data;
using G4_HotelManagerDEMO.Models;
using Microsoft.Identity.Client;
using System.Data;

namespace G4_HotelManagerDEMO.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ISqlDataAccess _dataAccess;

        public EmployeeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<EmployeeModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployee_GetAll";

                return connection.Query<EmployeeModel>(
                                  storeProcedure,
                                  commandType: CommandType.StoredProcedure
                                    );
            }
        }

        public EmployeeModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployee_GetById";

                return connection.QueryFirstOrDefault<EmployeeModel>(
                                  storeProcedure,
                                  new { IdEmployee = id },
                                  commandType: CommandType.StoredProcedure
                                    );
            }
        }
        public void Add(EmployeeModel employee)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployee_Insert";

                connection.Execute
                    (
                        storeProcedure,
                        new { employee.emploName, employee.emploLastName, employee.emploAge, employee.emploJob , employee.emploEmail, employee.emploPhone },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployee_Delete";

                connection.Execute
                    (
                        storeProcedure,
                        new { IdEmployee = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(EmployeeModel employee)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.spEmployee_Update";

                connection.Execute
                    (
                        storeProcedure,
                        employee,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
