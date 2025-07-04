using Application.Intefaces.Services;
using Application.Services;
using Application.ViewModels.Reportes;
using Application.ViewModels.Rutas;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    public class RutasController : Controller
    {
        private readonly IRutasService _rutasService;

        public RutasController(IRutasService rutasService)
        {
            _rutasService = rutasService;
        }

        public async Task<IActionResult> Rutas()
        {
            var model = await _rutasService.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRuta(RutaHandlerViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRutaPost(RutaHandlerViewModel model)
        {
            var response = await _rutasService.Add(model);

            if (response == null)
            {
                return RedirectToAction("CreateRuta", model);
            }
            else
            {
                return RedirectToAction("Rutas");
            }
        }
    }
}
