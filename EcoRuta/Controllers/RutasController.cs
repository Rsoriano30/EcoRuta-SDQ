using Application.Intefaces.Services;
using Application.Services;
using Application.ViewModels.Camiones;
using Application.ViewModels.Reportes;
using Application.ViewModels.Rutas;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrador,Usuario")]
        public async Task<IActionResult> Index()
        {
            var model = await _rutasService.GetAll();

            return View(model);
        }

        #region Create
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult CreateRuta()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
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
        #endregion

        #region Edit
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> EditRuta(int id)
        {
            var model = await _rutasService.GetById(id);

            if (model == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> EditRutaPost(RutaViewModel model)
        {
            try
            {
                await _rutasService.Update(model, model.RutaId);
            }
            catch
            {
                return RedirectToAction("EditRuta", model);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> DeleteRuta(int id)
        {
            try
            {
                var model = await _rutasService.GetById(id);

                return View(model);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> DeleteRutaPost(int id)
        {
            try
            {
                await _rutasService.Delete(id);
            }
            catch
            {
                return RedirectToAction("DeleteRuta", id);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
