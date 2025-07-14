using Application.Intefaces.Services;
using Application.ViewModels.Asignaciones;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _asignacionesService.GetAllWithJoin();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsignPost(AsignacionSaveViewModel model)
        {
            try
            {
                await _asignacionesService.Add(model);

                if (model.RutaId == null)
                {
                    throw new Exception("El campo Ruta es obligatorio.");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                AsignacionesDetailsViewModel _model = new()
                {
                    RutaId = model.RutaId,
                    HorarioId = model.HorarioId,
                    ChoferId = model.ChoferId,
                    CamionId = model.CamionId
                };

                ViewBag.ModoEditar = false;

                return RedirectToAction("EditAsign", _model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAsign(int id, bool ModoEditar)
        {
            ViewBag.Rutas = await _rutasService.GetAll();
            ViewBag.Horarios = await _horariosService.GetAll();
            ViewBag.Camiones = await _camionesService.GetAll();
            ViewBag.Choferes = await _choferesService.GetAll();
            ViewBag.ModoEditar = ModoEditar;

            AsignacionesDetailsViewModel model = new();
            if (ModoEditar)
            {
                try
                {
                    model = await _asignacionesService.GetWithJoin(id);
                }
                catch
                {
                    return RedirectToAction("PageNotFound", "Home");
                }

                return View(model);
            }
            else
            {
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditAsignPost(AsignacionViewModel model)
        {
            try
            {
                await _asignacionesService.Update(model, model.AsignacionId);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsignPost(int id)
        {
            try
            {
                await _asignacionesService.Delete(id);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}