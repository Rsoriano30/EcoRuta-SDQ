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

        public async Task<IActionResult> Index()
        {
            var model = await _rutasService.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRuta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRutaPost(RutaSaveViewModel model)
        {
            try
            {
                _rutasService.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("CreateRuta", model);
            }
        }
    }
}
