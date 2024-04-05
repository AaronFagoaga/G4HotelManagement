using Microsoft.AspNetCore.Mvc;
using G4_HotelManagerDEMO.Repositories.Hotels;
using G4_HotelManagerDEMO.Models;

namespace G4_HotelManagerDEMO.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public ActionResult Index()
        {
            return View(_hotelRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelModel hotel)
        {
            try
            {
                _hotelRepository.Add(hotel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(hotel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelModel hotel)
        {
            try
            {
                _hotelRepository.Edit(hotel);

                TempData["editHotel"] = "Se editó el hotel";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(hotel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HotelModel hotel)
        {
            try
            {
                _hotelRepository.Delete(hotel.IdHotel);

                TempData["deleteHotel"] = "Se eliminó el hotel";    

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["deleteHotel"] = ex.Message;

                return View(hotel);
            }
        }
    }
}
