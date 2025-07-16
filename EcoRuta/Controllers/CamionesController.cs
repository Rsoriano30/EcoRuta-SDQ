using Application.Intefaces.Services;
using Application.ViewModels.Camiones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CamionesController : Controller
    {
        private readonly ICamionesService _camionesService;

        public CamionesController(ICamionesService camionesService)
        {
            _camionesService = camionesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _camionesService.GetAll();
            
            return View(model);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateCamion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCamionPost(CamionSaveViewModel model)
        {
            try
            {
                await _camionesService.Add(model);
            }
            catch
            {
                return View("CreateCamion", model);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditCamion(int id)
        {
            var model = await _camionesService.GetById(id);

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
        public async Task<IActionResult> EditCamionPost(CamionViewModel model)
        {
            try
            {
                await _camionesService.Update(model, model.CamionId);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> DeleteCamion(int id)
        {
            try
            {
                var model = await _camionesService.GetById(id);

                return View(model);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCamionPost(int id)
        {
            try
            {
                await _camionesService.Delete(id);
            }
            catch
            {
                return RedirectToAction("DeleteCamion", id);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
