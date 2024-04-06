using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employee);
        void Delete(int id);
        void Edit(EmployeeModel employee);
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel? GetById(int id);
    }
}
