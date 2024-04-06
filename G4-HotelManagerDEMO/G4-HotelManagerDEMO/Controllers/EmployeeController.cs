using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace G4_HotelManagerDEMO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepositoy)
        {
            _employeeRepository = employeeRepositoy;
        }
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeModel employee)
        {
            try
            {
                _employeeRepository.Add(employee);

                TempData["message"] = "Datos guardados con exito";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(employee);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel employee)
        {
            try
            {
                _employeeRepository.Edit(employee);

                TempData["editEmployee"] = "Se editó con exito";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeModel employee)
        {
            try
            {
                _employeeRepository.Delete(employee.IdEmployee);

                TempData["deleteEmployee"] = "Se eliminó el empleado con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["deleteEmployee"] = ex.Message;

                return View(employee);
            }
        }
    }
}
