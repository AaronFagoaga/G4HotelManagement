using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.Reservations;
using G4_HotelManagerDEMO.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace G4_HotelManagerDEMO.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IEmailService _emailService;

        private SelectList _roomstList;
        private SelectList _clientsList;
        private SelectList _employeesList;

        public ReservationController(IReservationRepository reservationRepository, IEmailService emailService)
        {
            _reservationRepository = reservationRepository;
            _emailService = emailService;

            //Listas
            _roomstList = new SelectList(
                _reservationRepository.GetAllRooms(),
                nameof(RoomModel.IdRoom),
                nameof(RoomModel.roomName)
            );
            _clientsList = new SelectList(
                _reservationRepository.GetAllClient(),
                nameof(ClientModel.IdClient),
                nameof(ClientModel.clientName)
            );
            _employeesList = new SelectList(
                _reservationRepository.GetAllEmployees(),
                nameof(EmployeeModel.IdEmployee),
                nameof(EmployeeModel.emploName)
            );
        }

        // GET: ReservationsController
        public ActionResult Index()
        {
            return View(_reservationRepository.GetAll());
        }

        // GET: ReservationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationsController/Create
        public ActionResult Create()
        {
            ViewBag.Rooms = _roomstList;
            ViewBag.Clients = _clientsList;
            ViewBag.Employees = _employeesList;

            return View();
        }

        // POST: ReservationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.Add(reservation);

                TempData["message"] = "Datos guardados correctamente.";

                string emailTo = "sraaron1@GDD.com";
                string email = "reservafacilsv@gmail.com";
                string subject = "¡Reservación creada!";
                string body = "Test";

                _emailService.SendEmail(emailTo, email, subject, body);


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Rooms = _roomstList;
                ViewBag.Clients = _clientsList;
                ViewBag.Employees = _employeesList;

                return View(reservation);
            }
        }

        // GET: ReservationsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            _roomstList = new SelectList(
                _reservationRepository.GetAllRooms(),
                nameof(RoomModel.IdRoom),
                nameof(RoomModel.roomName),
                reservation?.Room?.IdRoom
            );
            _clientsList = new SelectList(
                _reservationRepository.GetAllClient(),
                nameof(ClientModel.IdClient),
                nameof(ClientModel.clientName),
                reservation?.Client?.IdClient
            );
            _employeesList = new SelectList(
                _reservationRepository.GetAllEmployees(),
                nameof(EmployeeModel.IdEmployee),
                nameof(EmployeeModel.emploName),
                reservation?.Employee?.IdEmployee
            );

            ViewBag.Rooms = _roomstList;
            ViewBag.Clients = _clientsList;
            ViewBag.Employees = _employeesList;

            return View(reservation);
        }

        // POST: ReservationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.Edit(reservation);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Rooms = _roomstList;
                ViewBag.Clients = _clientsList;
                ViewBag.Employees = _employeesList;

                return View(reservation);
            }
        }

        // GET: ReservationsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: ReservationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReservationModel reservation)
        {
            try
            {
                _reservationRepository.Delete(reservation.IdReservation);

                TempData["message"] = "Dato eliminado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(reservation);
            }
        }
    }
}

