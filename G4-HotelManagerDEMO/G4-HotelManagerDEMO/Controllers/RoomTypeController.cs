using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.RoomTypes;
using Microsoft.AspNetCore.Mvc;

namespace G4_HotelManagerDEMO.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeRepository _typeRepository;

        public RoomTypeController(IRoomTypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public ActionResult Index()
        {
            return View(_typeRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomTypeModel type)
        {
            try
            {
                _typeRepository.Add(type);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(type);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var type = _typeRepository.GetById(id);

            if (type == null)
            {
                return NotFound();
            }

            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomTypeModel type)
        {
            try
            {
                _typeRepository.Edit(type);

                TempData["editType"] = "Se editó el tipo";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(type);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var type = _typeRepository.GetById(id);

            if (type == null)
            {
                return NotFound();
            }
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoomTypeModel type)
        {
            try
            {
                _typeRepository.Delete(type.IdType);

                TempData["deleteType"] = "Se eliminó el tipo";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(type);
            }
        }
    }
}