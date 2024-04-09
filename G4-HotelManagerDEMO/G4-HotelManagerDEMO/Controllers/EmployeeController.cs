using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.Employee;
using G4_HotelManagerDEMO.Services.Email;
using Microsoft.AspNetCore.Mvc;

namespace G4_HotelManagerDEMO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
		private readonly IEmailService _emailService;

        public EmployeeController(IEmployeeRepository employeeRepositoy, IEmailService emailService)
        {
            _employeeRepository = employeeRepositoy;
			_emailService = emailService;
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

                TempData["message"] = "Datos guardados con exito, se envió un correo al nuevo empleado.";
				string emailTo = employee.emploEmail;
				string recipientName = employee.emploName + " " + employee.emploLastName;
				string subject = "¡Bienvenido al equipo!";
				string person = "Employee";

				_emailService.SendEmail(emailTo, recipientName, subject, person);
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
