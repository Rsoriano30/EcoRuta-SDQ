using Application.Intefaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly IRutasService _rutasService;
        private readonly ICamionesService _camionesService;
        private readonly IHorariosService _horariosService;
        private readonly IChoferesService _choferesService;
        private readonly IAsignacionesService _asignacionesService;

        public AsignacionesController(
            IAsignacionesService asignacionesService, 
            IChoferesService choferesService,
            ICamionesService camionesService,
            IRutasService rutasService,
            IHorariosService horariosService)
        {
            _asignacionesService = asignacionesService;
            _choferesService = choferesService;
            _camionesService = camionesService;
            _rutasService = rutasService;
            _horariosService = horariosService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.rutas = await _rutasService.GetAll();
            ViewBag.camiones = await _camionesService.GetAll();
            ViewBag.choferes = await _choferesService.GetAll();
            ViewBag.horarios = await _horariosService.GetAll();

            var model = await _asignacionesService.GetAll();

            return View(model);
        }
    }
}
