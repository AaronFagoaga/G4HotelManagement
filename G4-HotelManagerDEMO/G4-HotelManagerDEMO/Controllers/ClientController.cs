using G4_HotelManagerDEMO.Models;
using G4_HotelManagerDEMO.Repositories.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace G4_HotelManagerDEMO.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View(_clientRepository.GetAll());
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
        public IActionResult Create(ClientModel client)
        {
            try
            {
                _clientRepository.Add(client);

                TempData["message"] = "Datos guardados con exito";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(client);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            var client = _clientRepository.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientModel client)
        {
            try
            {
                _clientRepository.Edit(client);

                TempData["editClient"] = "Se editó con exito";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View(client);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var client = _clientRepository.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClientModel client)
        {
            try
            {
                _clientRepository.Delete(client.IdClient);

                TempData["deleteClient"] = "Se eliminó el cliente con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["DeleteClient"] = ex.Message;

                return View(client);
            }
        }
    }
}
