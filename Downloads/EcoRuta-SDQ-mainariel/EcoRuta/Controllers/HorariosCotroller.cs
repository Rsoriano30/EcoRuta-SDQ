using Application.Intefaces.Services;
using Application.Services;
using Application.ViewModels.Choferes;
using Application.ViewModels.Horarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HorariosController : Controller
    {
        IHorariosService _horariosService;

        public HorariosController(IHorariosService horariosService)
        {
            _horariosService = horariosService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _horariosService.GetAll();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateHorario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHorarioPost(HorarioSaveViewModel model)
        {
            try
            {
                await _horariosService.Add(model);
            }
            catch
            {
                return View("CreateHorario", model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditHorario(int id)
        {
            var model = await _horariosService.GetById(id);

            if (model == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditHorarioPost(HorarioViewModel model)
        {
            try
            {
                await _horariosService.Update(model, model.HorarioId);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            try
            {
                var model = await _horariosService.GetById(id);

                return View(model);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHorarioPost(int id)
        {
            try
            {
                await _horariosService.Delete(id);
            }
            catch
            {
                return RedirectToAction("DeleteHorario", id);
            }

            return RedirectToAction("Index");
        }
    }
}
