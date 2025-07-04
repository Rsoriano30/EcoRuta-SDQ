using Application.Intefaces.Services;
using Application.ViewModels.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace EcoRuta.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IReportesService _reportesService;

        public ReportesController(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        public async Task<IActionResult> Reportes()
        {
            var model = await _reportesService.GetAll();

            return View(model);
        }

        #region Edit
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

                return RedirectToAction("Reportes", "Reportes");
            }
            catch
            {
                return RedirectToAction("EditReportePost", model.ReporteId);
            }
        }
        #endregion

        #region Create

        [HttpGet]
        public IActionResult CreateReporte(ReporteHandlerViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportePost(ReporteHandlerViewModel model)
        {
            var response = await _reportesService.Add(model);

            if (response == null)
            {
                return RedirectToAction("CreateReporte", model);
            }
            else
            {
                return RedirectToAction("Reportes");
            }
        }

        #endregion

        #region Delete

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

                return RedirectToAction("Reportes", "Reportes");
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
