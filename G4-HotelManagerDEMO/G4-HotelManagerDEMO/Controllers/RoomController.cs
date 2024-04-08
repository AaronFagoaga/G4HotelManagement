using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.Rooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace G4_HotelManagerDEMO.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        private SelectList _roomsTypesList;
        private SelectList _hotelsList;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _roomsTypesList = new SelectList(
                _roomRepository.GetAllRoomTypes(),
                nameof(RoomTypeModel.IdType),
                nameof(RoomTypeModel.typeName)
            );
            _hotelsList = new SelectList(
                _roomRepository.GetAllHotel(),
                nameof(HotelModel.IdHotel),
                nameof(HotelModel.hotelName)
            );
        }

        // GET: RoomController
        public ActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            ViewBag.RoomsTypes = _roomsTypesList;
            ViewBag.Hotels = _hotelsList;

            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomModel room)
        {
            try
            {
                _roomRepository.Add(room);

                TempData["message"] = "Datos guardados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.RoomsTypes = _roomsTypesList;
                ViewBag.Hotels = _hotelsList;

                return View(room);
            }
        }

        // GET: RoomController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = _roomRepository.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            _roomsTypesList = new SelectList(
                _roomRepository.GetAllRoomTypes(),
                nameof(RoomTypeModel.IdType),
                nameof(RoomTypeModel.typeName),
                room?.RoomType?.IdType
            );
            _hotelsList = new SelectList(
                _roomRepository.GetAllHotel(),
                nameof(HotelModel.IdHotel),
                nameof(HotelModel.hotelName),
                room?.Hotel?.IdHotel
            );

            ViewBag.RoomsTypes = _roomsTypesList;
            ViewBag.Hotels = _hotelsList;

            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomModel room)
        {
            try
            {
                _roomRepository.Edit(room);

                TempData["message"] = "Datos editados correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.RoomsTypes = _roomsTypesList;
                ViewBag.Hotels = _hotelsList;

                return View(room);
            }
        }

        // GET: RoomController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var room = _roomRepository.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoomModel room)
        {
            try
            {
                _roomRepository.Delete(room.IdRoom);

                TempData["message"] = "Dato eliminado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(room);
            }
        }
    }
}
