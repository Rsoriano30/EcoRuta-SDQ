using Application.Intefaces.Services;
using Application.ViewModels.Reportes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcoRuta.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReportesService _reportesService;

        public ReportesController(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [Authorize(Roles = "Usuario,Administrador")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int user_id = 0;

            try
            {
                user_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString());
            }
            catch
            {
            }
            
            switch (User.IsInRole("Administrador"))
            {
                case true:
                    var full_model = await _reportesService.GetCurrentMothReportesPendientes();
                    return View(full_model);

                case false:
                    var my_model = await _reportesService.GetByUsuarioId(user_id);
                    return View(my_model);
            }
        
        }

        [Authorize(Roles = "Usuario,Administrador")]
        [HttpGet]
        public async Task<IActionResult> Detalles(int id)
        {
            var model = await _reportesService.GetById(id);

            return View(model);
        }

        #region Edit
        [Authorize(Roles = "Usuario,Administrador")]
        [HttpGet]
        public async Task<IActionResult> EditReporte(int Id)
        {
            var model = await _reportesService.GetById(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditReportePost(ReporteViewModel model)
        {
            try
            {
                await _reportesService.Update(model, model.ReporteId);

                return RedirectToAction("Index", "Reportes");
            }
            catch
            {
                return RedirectToAction("EditReportePost", model.ReporteId);
            }
        }
        #endregion

        #region Create

        [Authorize(Roles = "Usuario,Administrador")]
        [HttpGet]
        public IActionResult CreateReporte(ReporteSaveViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportePost(ReporteSaveViewModel model)
        {
            try
            {
                await _reportesService.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("CreateReporte", model);
            }
        }

        #endregion

        #region Delete
        [Authorize(Roles = "Usuario,Administrador")]
        [HttpGet]
        public async Task<IActionResult> DeleteReporte(int Id)
        {
            var model = await _reportesService.GetById(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReportePost(int Id)
        {
            try
            {
                Console.WriteLine(Id);
                await _reportesService.Delete(Id);

                return RedirectToAction("Index", "Reportes");
            }
            catch (Exception ex)
            {
                var model = await _reportesService.GetById(Id);

                return View("DeleteReporte", model);
            }
        }

        #endregion
    }
}
